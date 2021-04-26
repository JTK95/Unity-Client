using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//---------------------------------------------------------------
// 씬 전환
//---------------------------------------------------------------
namespace Client
{
    public class SceneLoad : MonoBehaviour
    {
        public UInt16 _getAccountId;

        void Start()
        {
            _getAccountId = AllScene._uid;
        }

        // mainScene
        public void GoToMain()
        {
            SceneManager.LoadScene(1);
        }

        // 회원가입 씬
        public void GoToRegister()
        {
            SceneManager.LoadScene(2);
        }

        // 로그인 씬
        public void GoToLogin()
        {
            SceneManager.LoadScene(3);
        }

        //// 게임 씬
        //public void GoToGame()
        //{
        //    SceneManager.LoadScene(4);
        //}

        public void GoToRoom1()
        {
            // 룸 접속 패킷 송신
            Client.PK_C_REQ_CONNECT_ROOM packet = new Client.PK_C_REQ_CONNECT_ROOM();
            packet._roomNumber = 1;
            packet._uid = AllScene._uid;
            packet._charName = AllScene._name;
            Client.NetworkManager.GetInstance.sendPacket(packet);

            AllScene._roomNuber = packet._roomNumber;

            //Debug.Log("accountId : " + packet._accountId);
        }

        public void GoToRoom2()
        {
            //SceneManager.LoadScene(5);

            // 룸 접속 패킷 송신
            Client.PK_C_REQ_CONNECT_ROOM packet = new Client.PK_C_REQ_CONNECT_ROOM();
            packet._roomNumber = 2;
            packet._uid = AllScene._uid;
            packet._charName = AllScene._name;
            Client.NetworkManager.GetInstance.sendPacket(packet);

            AllScene._roomNuber = packet._roomNumber;
        }

        public void GoToRoom3()
        {
            //SceneManager.LoadScene(5);

            // 룸 접속 패킷 송신
            Client.PK_C_REQ_CONNECT_ROOM packet = new Client.PK_C_REQ_CONNECT_ROOM();
            packet._roomNumber = 3;
            packet._uid = AllScene._uid;
            packet._charName = AllScene._name;
            Client.NetworkManager.GetInstance.sendPacket(packet);

            AllScene._roomNuber = packet._roomNumber;
        }

        public void GoToDummyClient()
        {
            // 룸 접속 패킷 송신
            Client.PK_C_REQ_CONNECT_ROOM packet = new Client.PK_C_REQ_CONNECT_ROOM();
            packet._roomNumber = 4;
            packet._uid = AllScene._uid;
            packet._charName = AllScene._name;
            Client.NetworkManager.GetInstance.sendPacket(packet);

            AllScene._roomNuber = packet._roomNumber;
        }

        //public void GoToRoom4()
        //{
        //    //SceneManager.LoadScene(5);

        //    // 룸 접속 패킷 송신
        //    Client.PK_C_REQ_CONNECT_ROOM packet = new Client.PK_C_REQ_CONNECT_ROOM();
        //    packet._roomNumber = 4;
        //    packet._accountId = AllScene._uid;
        //    packet._charName = AllScene._name;
        //    Client.NetworkManager.GetInstance.sendPacket(packet);

        //    AllScene._roomNuber = packet._roomNumber;
        //}

        public void GoToBack()
        {
            // 룸 나가기 패킷 송신
            Client.PK_C_REQ_EXIT_ROOM packet = new Client.PK_C_REQ_EXIT_ROOM();
            packet._roomNumber = AllScene._roomNuber;
            packet._uid = AllScene._uid;
            packet._charName = AllScene._name;
            Client.NetworkManager.GetInstance.sendPacket(packet);

            // Lobby Scene
            SceneManager.LoadScene(4);
        }

        public void QuitGame()
        {
            // 여기서 종료 패킷 송신
            Client.PK_C_REQ_EXIT packet = new Client.PK_C_REQ_EXIT();
            packet._uid = _getAccountId;
            Client.NetworkManager.GetInstance.sendPacket(packet);

            // 여기서 소켓 종료
            Client.NetworkManager.GetInstance.close();

            // Connect Scene
            SceneManager.LoadScene(0);
        }
    }
}
