using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Registration : MonoBehaviour
{
    public InputField _nameField; // ID
    public InputField _passwordField; // PW

    public void RegisterClick()
    {
        Client.PK_C_REQ_REGISTER packet = new Client.PK_C_REQ_REGISTER();
        packet._charName = _nameField.text.ToString();
        packet._password = _passwordField.text.ToString();
        Client.NetworkManager.GetInstance.sendPacket(packet);
    }

}














//public InputField _nameField; // ID
//public InputField _passwordField; // PW

//public Button _submitButton;

//public Text _registerCheck;

//MainMenu socket;

//public void RegisterClick()
//{
//    byte[] receiverBuffer = new byte[8192];

//    socket = GameObject.Find("ServerConnect").GetComponent<MainMenu>();

//    byte[] Buffer = Encoding.UTF8.GetBytes(_nameField.text + ' ' + _passwordField.text + '+');

//    // 데이터 송신
//    socket._Socket.Send(Buffer, SocketFlags.None);

//    // 데이터 수신
//    int n = socket._Socket.Receive(receiverBuffer);

//    string data = Encoding.UTF8.GetString(receiverBuffer, 0, n);

//    _registerCheck.text = data;
//}