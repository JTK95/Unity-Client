using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Threading;
using System;
using System.IO;

namespace Client
{
    internal class NetworkManager : Singleton<NetworkManager>
    {
        internal enum NET_STATE
        {
            START,
            CONNECTED,
            DISCONNECT,
            DISCONNECTED
        }

        internal enum PROGRAM_STATE
        {
            LOGIN,
            CHATTING,
            GAME
        }

        public string _ip;
        public uint _port;
        public string _name; // username
       // public bool _socketCheck;

        public Dictionary<PacketType, Action<PacketInterface>> packetCallback = new Dictionary<PacketType, Action<PacketInterface>>();
        public Queue<PacketInterface> _recvPacket = new Queue<PacketInterface>();

        public PacketProcess _serverForm;
        private NetworkStream _stream;
        public TcpClient _client; // 클라이언트 소켓

        private NET_STATE _netState = NET_STATE.START;
        public PROGRAM_STATE _processState = PROGRAM_STATE.LOGIN;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
           // _socketCheck = true;

            _serverForm = new AllPacketProcess();

            Debug.Log("start start");
            _ip = "127.0.0.1";
            _port = 9300;

            connect(_ip, _port);
            StartCoroutine("receive");
        }

        private void Update()
        {
            //if (!_socketCheck)
            //{
            //    this.OnDestory();
            //    AllScene._check = false;
            //    //Destroy(gameObject);
            //}

            while (_recvPacket.Count != 0)
            {
                //if(_recvPacket == null)
                //{
                //    Debug.Log("nullllllllll");
                //    continue;
                //}

                //if(_serverForm == null)
                //{
                //    Debug.Log("CONTINUEEEEE");
                //    continue;
               
                //}

                PacketInterface temp = _recvPacket.Dequeue();

                //Debug.Log(" temp = " + temp);
                _serverForm.run(temp);
            }
        }

        public override void OnDestory()
        {
            // 연결이 되어있으면 연결 해제
            if (this.isConnected())
            {
               this.disConnect();
            }

            this.close();
        }

        NET_STATE nstate()
        {
            return _netState;
        }

        PROGRAM_STATE pstate()
        {
            return _processState;
        }

        public void close()
        {
            _netState = NET_STATE.DISCONNECTED;

            _stream.Close();
            _stream.Flush();
            _client.Close();
            _serverForm = null;
        }

        //----------------------------------------------------------------------
        // 다른 프로그램 상태 변화와 connect
        //----------------------------------------------------------------------
        public void setState(PROGRAM_STATE state, string ip, uint port)
        {
            //----------------------------------------------------------------------------
            // 프로그램의 상태를 바꾸기 위해 state와 ip, port번호를 바꾸어주는 함수
            // 바뀐 ip, port번호로 connect
            //----------------------------------------------------------------------------
            _processState = state;
            _ip = ip;
            _port = port;

            disConnect();
            connect(_ip, _port);
        }

        public bool connect(string ip, uint port)
        {
            if (_client == null)
            {
                _client = new TcpClient();
            }

            try
            {
                Debug.Log(ip);
                Debug.Log(port);

                // connect
                _client.Connect(ip, Convert.ToInt32(port));

                // 네트워크 스트림을 얻어옴
                _stream = _client.GetStream();
            }
            catch
            {
                Debug.Log("서버 연결 실패");
                _client.Connect(ip, Convert.ToInt32(port));

                return false;
            }

            _netState = NET_STATE.CONNECTED;

            // 네트워크 스트림을 얻어옴
            _stream = _client.GetStream();

            return true;
        }

        public void disConnect()
        {
            _netState = NET_STATE.DISCONNECT;
            _stream.Close();
            _client.Close();
            _client = null;
        }

        public void setPacketProcess(PacketProcess packetProcess)
        {
            _serverForm = packetProcess;
        }

        private bool isConnected()
        {
            return _netState == NET_STATE.CONNECTED ? true : false;
        }

        // send
        public void sendPacket(PacketInterface packet)
        {
            try
            {
                packet.Encoding();
                MemoryStream packetBlock = new MemoryStream();

                // 패킷 길이
                Int32 packetLen = sizeof(Int32) + (Int32)packet.GetStream().Length;
                
                // 헤더 추가 (패킷 바이트 크기)
                Byte[] packetHeader = BitConverter.GetBytes(packetLen);
                packetBlock.Write(packetHeader, 0, (Int32)packetHeader.Length);

                // 데이터 추가
                Byte[] packetData = packet.GetStream().ToArray();
                packetBlock.Write(packetData, 0, (Int32)packetData.Length);

                // 서버로 송신
                Byte[] packetBytes = packetBlock.ToArray();
                //Debug.Log("Send Packet Type : " + packet.type().ToString());
                //Debug.Log("Send Packet Length : " + packetLen.ToString());
                _stream.Write(packetBytes, 0, (int)packetBlock.Length);
                _stream.Flush();

                packetBlock = null;
            }
            catch (Exception e)
            {
                if (this.isConnected())
                {
                    Debug.Log(e);
                    Debug.Log("sendPacket() Error");
                    return;
                }
            }
        }

        // recv
        IEnumerator receive()
        {
            yield return null;
            
            while(this.isConnected())
            {
                yield return null;

                // 데이터가 없으면
                if(!_stream.DataAvailable)
                {
                    continue;
                }

                Byte[] packetByte = new Byte[_client.ReceiveBufferSize];
                Byte[] packetData = new Byte[_client.ReceiveBufferSize];
                Byte[] packetDataLenBuffer = new Byte[sizeof(Int32)];
                
                Int32 offset = 0;
                Int32 packetDataLen = 0;

                // 읽을 길이
                Int32 readLen = _stream.Read(packetByte, offset, packetByte.Length); 

                // 패킷 전체 길이
                Int32 packetLen = PacketUtil.DecodingPacketLen(packetByte, ref offset);

                // 모두 읽을때 까지 반복
                while(readLen < packetLen)
                {
                    Byte[] remainPacket = new Byte[_client.ReceiveBufferSize];
                    Int32 remainLen = 0;

                    remainLen = _stream.Read(remainPacket, 0, remainPacket.Length);
                    Buffer.BlockCopy(remainPacket, 0, packetByte, readLen, remainLen);
                    readLen += remainLen;
                }

                // packetByte에서 처음 4byte를 읽어 전체길이를 알아낸 후 그 길이만큼 자른다
                do
                {
                    // -->
                    Buffer.BlockCopy(packetByte, 0, packetDataLenBuffer, 0, 4);

                    // 전체길이에서 헤더 사이즈만큼 빼준다
                    packetDataLen = BitConverter.ToInt32(packetDataLenBuffer, 0) - 4;
                    if (packetDataLen < 1)
                    {
                        break;
                    }

                    // 데이터 사이즈만큼 복사
                    Buffer.BlockCopy(packetByte, 4, packetData, 0, packetDataLen);

                    // ----> 로그 남겨서 에러 떳을때 확인
                    //string message = "";

                    //message = "packetByte : " + packetByte + "\npacketDataLen" + packetDataLen;
                    //AllScene._textQueue.Enqueue(message);
                    //Debug.Log("packet Byte : " + packetByte);
                    //Debug.Log("packetDataLen : " + packetDataLen);

                    // 읽은 데이터만큼 버퍼를 앞으로 옮긴다
                    Buffer.BlockCopy(packetByte, packetDataLen + 4, packetByte, 0, packetByte.Length - packetDataLen - 4);
                    Debug.Log("zzzzzzzzzz");
                    PacketInterface rowPacket = PacketUtil.PacketAnalyzer(packetData);
                    if (rowPacket == null && this.isConnected())
                    {
                        Debug.Log("잘못 된 패킷이 수신되었습니다");
                    }
                    else
                    {
                        _recvPacket.Enqueue(rowPacket);
                        //Debug.Log(rowPacket.type());
                        //Debug.Log(readLen);
                    }
                } while (packetDataLen > 4);
            }

            this.close();
        }
        // TODO...
        //private void heartBeat()
    }
}

// =========================================================================================
// Coroutine은 프레임과 상관없이 별도의 서브 루틴에서 원하는 작업을 원하는 시간만큼 수행한다
// Coroutine은 Update()함수에 종속적이지 않으며, 마치 별도의 쓰레드와 같이 동작을 한다.
//
// yield return문이 존재하지 않으면 Coroutine은 종료한다
// =========================================================================================