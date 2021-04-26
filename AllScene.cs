using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using Client;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
//using System;

public class AllScene : MonoBehaviour
{
    private static AllScene instance;

    public static AllScene Instance { get { return instance; } }

    public static bool _check;
    public GameObject prefab;
    static GameObject Resource;

    public GameObject minimapPrefab;
    static GameObject minimapResource;

    // userMap
    public static Dictionary<System.UInt16, User> _UserMap = new Dictionary<System.UInt16, User>();

    // minimapMap
    public static Dictionary<System.UInt16, MiniMapUser> _minimapUserMap = new Dictionary<System.UInt16, MiniMapUser>();

    public static System.UInt16 _uid;
    public static string _name;
    public static byte _roomNuber;
    
    // 받은 message 정보를 큐로 관리
    public static Queue<string> _textQueue = new Queue<string>();

    private Vector3 _prevPos;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _check = true;

        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_EXIT, S_ANS_EXIT);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_REGISTER_FAIL, S_ANS_REGISTER_FAIL);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_REGISTER_SUCCESS, S_ANS_REGISTER_SUCCESS);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_LOGIN_FAIL, S_ANS_LOGIN_FAIL);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_LOGIN_SUCCESS, S_ANS_LOGIN_SUCCESS);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_NOTIFY_LOGIN_CLIENT, S_NOTIFY_LOGIN_CLIENT);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_CONNECT_ROOM, S_ANS_CONNECT_ROOM);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_CONNECT_FAIL_ROOM, S_ANS_CONNECT_FAIL_ROOM);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_NOTIFY_CONNECT_ROOM_CLIENT, S_NOTIFY_CONNECT_ROOM_CLIENT);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_PLAYER_MOVE, S_ANS_PLAYER_MOVE);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_BULLET_SHOOT, S_ANS_BULLET_SHOOT);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_COLLISION_CHECK, S_ANS_COLLISION_CHECK);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_CHAT_OUTPUT, S_ANS_CHAT_OUTPUT);
        Client.NetworkManager.GetInstance.packetCallback.Add(Client.PacketType.E_S_ANS_EXIT_ROOM, S_ANS_EXIT_ROOM);

        // enemy
        Resource = prefab;
        minimapResource = minimapPrefab;
        //Resource = Resources.Load("DummyPlayer") as GameObject;
    }

    void Update()
    {
        //if (!_check)
        //{
        //    this.OnDestroy();
        //   // Destroy(gameObject);
        //}
    }

    private void OnDestroy()
    {
        //Debug.Log("OnDestroy1");
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_EXIT);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_REGISTER_FAIL);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_REGISTER_SUCCESS);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_LOGIN_FAIL);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_LOGIN_SUCCESS);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_NOTIFY_LOGIN_CLIENT);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_CONNECT_ROOM);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_CONNECT_FAIL_ROOM);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_NOTIFY_CONNECT_ROOM_CLIENT);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_PLAYER_MOVE);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_BULLET_SHOOT);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_COLLISION_CHECK);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_CHAT_OUTPUT);
        Client.NetworkManager.GetInstance.packetCallback.Remove(Client.PacketType.E_S_ANS_EXIT_ROOM);
    }

    //--------------------------------------------------------------------------------
    // 기본 패킷 기능
    //--------------------------------------------------------------------------------
    public static void S_ANS_EXIT(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_EXIT packet = (Client.PK_S_ANS_EXIT)rowPacket;

        User user = _UserMap[packet._uid];
        user.DeleteCharacter();

        MiniMapUser miniUser = _minimapUserMap[packet._uid];
        miniUser.DeleteCharacter();

        _UserMap.Remove(user.UID);
        _minimapUserMap.Remove(miniUser.UID);

        //Client.NetworkManager.GetInstance._socketCheck = false;
        //Client.NetworkManager.GetInstance.OnDestory();
    }

    //--------------------------------------------------------------------------------
    // 회원가입 기능
    //--------------------------------------------------------------------------------
    public static void S_ANS_REGISTER_FAIL(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_REGISTER_FAIL packet = (Client.PK_S_ANS_REGISTER_FAIL)rowPacket;

        Debug.Log("[" + packet._charName +"] 중복 된 아이디가 있습니다");

        RegisterEvent.current.RegisterFail();
    }

    public static void S_ANS_REGISTER_SUCCESS(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_REGISTER_SUCCESS packet = (Client.PK_S_ANS_REGISTER_SUCCESS)rowPacket;
        Debug.Log("회원가입 성공");
    }

    //--------------------------------------------------------------------------------
    // 로그인 기능
    //--------------------------------------------------------------------------------
    public static void S_ANS_LOGIN_FAIL(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_LOGIN_FAIL packet = (Client.PK_S_ANS_LOGIN_FAIL)rowPacket;
        
        Debug.Log("[" + packet._charName + "] 로그인 실패");

        LoginEvent.current.LoginFail();
    }

    static PlayerHealth player;
    static SphereMovement mimiPlayer;
    public static void S_ANS_LOGIN_SUCCESS(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_LOGIN_SUCCESS packet = (Client.PK_S_ANS_LOGIN_SUCCESS)rowPacket;
        Debug.Log("로그인 성공");
        
        _uid = packet._uid;
        _name = packet._charName;

        // Lobby Scene
        SceneManager.LoadScene(4);

        // 유저 접속 패킷 송신
        Client.PK_C_NOTIFY_LOGIN_CLIENT retPacket = new Client.PK_C_NOTIFY_LOGIN_CLIENT();
        retPacket._uid = packet._uid;
        retPacket._charName = packet._charName;
        Client.NetworkManager.GetInstance.sendPacket(retPacket);
    }

    //--------------------------------------------------------------------------------
    // InGame 기능
    //--------------------------------------------------------------------------------
    public static void S_NOTIFY_LOGIN_CLIENT(Client.PacketInterface rowPacket)
    {
        Client.PK_S_NOTIFY_LOGIN_CLIENT packet = (Client.PK_S_NOTIFY_LOGIN_CLIENT)rowPacket;

        string message = "";

        if (packet._check)
        {
            message = "<color=#ff0000>" + ' ' + packet._charName + " 님이 접속 하였습니다." + "</color>";
            _textQueue.Enqueue(message);
        }
        Debug.Log(packet._charName + " 님이 접속 하였습니다.");
    }
    
    public static void S_ANS_CONNECT_ROOM(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_CONNECT_ROOM packet = (Client.PK_S_ANS_CONNECT_ROOM)rowPacket;

        // InGame Scene
        SceneManager.LoadScene(5);

        // Debug.Log("ㅅㅂ 존나안뜨네");
       
        // 여기서 PK_C_NOTIFY_CONNECT_ROOM_CLIENT 패킷 송신
        Client.PK_C_NOTIFY_CONNECT_ROOM_CLIENT retPacket = new Client.PK_C_NOTIFY_CONNECT_ROOM_CLIENT();
        retPacket._roomNumber = packet._roomNumber;
        retPacket._uid = packet._uid;
        retPacket._charName = packet._charName;
        Client.NetworkManager.GetInstance.sendPacket(retPacket);
    }

    public static void S_ANS_CONNECT_FAIL_ROOM(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_CONNECT_FAIL_ROOM packet = (Client.PK_S_ANS_CONNECT_FAIL_ROOM)rowPacket;

        Debug.Log(packet._uid + " 방 입장 불가");

        LobbyEvent.current.ConnectRoomFail();
    }

    public static void S_NOTIFY_CONNECT_ROOM_CLIENT(Client.PacketInterface rowPacket)
    {
        Client.PK_S_NOTIFY_CONNECT_ROOM_CLIENT packet = (Client.PK_S_NOTIFY_CONNECT_ROOM_CLIENT)rowPacket;

        // 프리팹 생성
        User createdUser = Instantiate(Resource, new Vector3(Random.Range(-26, 11), 0, Random.Range(-8, 30)), new Quaternion(0, 0, 0, 0)).GetComponent<User>();
        createdUser.UID = packet._uid;
        createdUser.CharName = packet._charName;

        // 미니맵 enemy 생성
        MiniMapUser createMinimapUser = Instantiate(minimapResource, new Vector3(createdUser.transform.position.x, 65.718f, createdUser.transform.position.z), new Quaternion(0, 0, 0, 0)).GetComponent<MiniMapUser>();
        createMinimapUser.UID = packet._uid;

        _UserMap.Add(createdUser.UID, createdUser);
        _minimapUserMap.Add(createMinimapUser.UID, createMinimapUser);

        string message = "";

        if (packet._check)
        {
            message = "<color=#ff0000>" + ' ' + packet._charName + " 님이 접속 하였습니다." + "</color>";
            _textQueue.Enqueue(message);
        }

        createdUser.SetUserUID(packet._uid);
       // createdUser.EnemyNamePrint(packet._charName);
    }

    public static void S_ANS_PLAYER_MOVE(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_PLAYER_MOVE packet = (Client.PK_S_ANS_PLAYER_MOVE)rowPacket;

        User user = _UserMap[packet._uid];
        user.Move(packet._Xpos, packet._Ypos, packet._Zpos, packet._Xrot, packet._Yrot, packet._Zrot);

        MiniMapUser miniUser = _minimapUserMap[packet._uid];
        miniUser.Move(packet._Xpos, packet._Zpos);
    }

    public static void S_ANS_BULLET_SHOOT(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_BULLET_SHOOT packet = (Client.PK_S_ANS_BULLET_SHOOT)rowPacket;
        
        User user = _UserMap[packet._uid];
        user.Shoot();
    }

    public static void S_ANS_COLLISION_CHECK(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_COLLISION_CHECK packet = (Client.PK_S_ANS_COLLISION_CHECK)rowPacket;

        User user = _UserMap[packet._uid];
        user.TakeDamage(10);
    }

    //--------------------------------------------------------------------------------
    // Chatting 기능
    //--------------------------------------------------------------------------------
    public static void S_ANS_CHAT_OUTPUT(Client.PacketInterface rowPacket)
    {
        string message = "";
        Client.PK_S_ANS_CHAT_OUTPUT packet = (Client.PK_S_ANS_CHAT_OUTPUT)rowPacket;

        message = ' ' + packet._charName + ": " + packet._text;
        _textQueue.Enqueue(message);
    }

    public static void S_ANS_EXIT_ROOM(Client.PacketInterface rowPacket)
    {
        Client.PK_S_ANS_EXIT_ROOM packet = (Client.PK_S_ANS_EXIT_ROOM)rowPacket;

        Debug.Log("EXIT_ROOM : " + packet._uid);

        User user = _UserMap[packet._uid];
        user.DeleteCharacter();

        MiniMapUser miniUser = _minimapUserMap[packet._uid];
        miniUser.DeleteCharacter();

        _UserMap.Remove(user.UID);
        _minimapUserMap.Remove(miniUser.UID);
    }
}




