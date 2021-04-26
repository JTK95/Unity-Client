using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UnityEngine.Experimental.UIElements;

namespace Client
{
    public class SignUp : MonoBehaviour
    {
        public InputField _nameField; // ID
        public InputField _passwordField; // PW

        public void LoginClick()
        {
            Client.PK_C_REQ_LOGIN packet = new Client.PK_C_REQ_LOGIN();
            packet._charName = _nameField.text;
            packet._password = _passwordField.text;
            Client.NetworkManager.GetInstance.sendPacket(packet);
        }
    }
}




//public Button _submitButton;

//public Text _loginCheck;

//MainMenu socket;

//public void LoginClick()
//{
//    byte[] receiverBuffer = new byte[8192];

//    socket = GameObject.Find("ServerConnect").GetComponent<MainMenu>();

//    byte[] buffer = Encoding.UTF8.GetBytes(_nameField.text + ' ' + _passwordField.text + '-');

//    // 데이터 송신
//    socket._Socket.Send(buffer, SocketFlags.None);

//    // 데이터 수신
//    int n = socket._Socket.Receive(receiverBuffer);

//    string data = Encoding.UTF8.GetString(receiverBuffer, 0, n);

//    _loginCheck.text = data;

//}

