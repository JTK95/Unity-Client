using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public class MainMenu : MonoBehaviour
    {
        private string _loginIp = "127.0.0.1"; // IP 주소
        private int _loginPort = 9000; // Port 번호
        public Socket _Socket;
        
        void Start()
        {
            // 오브젝트 소멸하지 않음
            DontDestroyOnLoad(gameObject);

            // 소켓 생성
            _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
            // 서버에 연결
            var ep = new IPEndPoint(IPAddress.Parse(_loginIp), _loginPort);
            _Socket.Connect(ep);
        }

        private void OnDestroy()
        {

            // 소켓 닫기
            _Socket.Close();

            Debug.Log("소켓 ㅂㅂ");
        }
    }
}