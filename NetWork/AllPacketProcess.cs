using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Client
{
    class AllPacketProcess : PacketProcess
    {
        public override void run(PacketInterface packet)
        {
            PacketType type = (PacketType)packet.type();
            Action<PacketInterface> _function = null; // 함수포인터

            switch(type)
            {
                case PacketType.E_S_ANS_EXIT:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_EXIT, out _function))
                    {
                        Debug.Log("E_S_ANS_EXIT 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_REGISTER_FAIL:
                    if(!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_REGISTER_FAIL, out _function))
                    {
                        Debug.Log("E_S_ANS_REGISTER_FAIL 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_REGISTER_SUCCESS:
                    if(!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_REGISTER_SUCCESS, out _function))
                    {
                        Debug.Log("E_S_ANS_REGISTER_SUCCESS 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_LOGIN_FAIL:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_LOGIN_FAIL, out _function))
                    {
                        Debug.Log("E_S_ANS_LOGIN_FAIL 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_LOGIN_SUCCESS:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_LOGIN_SUCCESS, out _function))
                    {
                        Debug.Log("E_S_ANS_LOGIN_SUCCESS 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_NOTIFY_LOGIN_CLIENT:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_NOTIFY_LOGIN_CLIENT, out _function))
                    {
                        Debug.Log("E_S_NOTIFY_LOGIN_CLIENT 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_CONNECT_ROOM:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_CONNECT_ROOM, out _function))
                    {
                        Debug.Log("E_S_ANS_CONNECT_ROOM 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_CONNECT_FAIL_ROOM:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_CONNECT_FAIL_ROOM, out _function))
                    {
                        Debug.Log("E_S_ANS_CONNECT_FAIL_ROOM 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_NOTIFY_CONNECT_ROOM_CLIENT:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_NOTIFY_CONNECT_ROOM_CLIENT, out _function))
                    {
                        Debug.Log("E_S_NOTIFY_CONNECT_ROOM_CLIENT 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_PLAYER_MOVE:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_PLAYER_MOVE, out _function))
                    {
                        Debug.Log("E_S_ANS_PLAYER_MOVE 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");

                        return;
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_BULLET_SHOOT:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_BULLET_SHOOT, out _function))
                    {
                        Debug.Log("E_S_ANS_BULLET_SHOOT 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_COLLISION_CHECK:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_COLLISION_CHECK, out _function))
                    {
                        Debug.Log("E_S_ANS_COLLISION_CHECK 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_CHAT_OUTPUT:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_CHAT_OUTPUT, out _function))
                    {
                        Debug.Log("E_S_ANS_CHAT_OUTPUT 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
                case PacketType.E_S_ANS_EXIT_ROOM:
                    if (!NetworkManager.GetInstance.packetCallback.TryGetValue(PacketType.E_S_ANS_EXIT_ROOM, out _function))
                    {
                        Debug.Log("E_S_ANS_EXIT_ROOM 패킷이 들어오지 않았거나 함수포인터 정의가 되어있지 않습니다");
                    }
                    _function(packet);
                    return;
            }

            if(base.defaultRun(packet) == false)
            {
#if DEBUG
                Debug.Log("잘못된 패킷이 수신되었습니다");
#endif
            }

        }
    }
}
