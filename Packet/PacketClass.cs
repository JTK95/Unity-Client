using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Client
{
    public class PK_C_REQ_EXIT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_EXIT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_EXIT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
    }

    public class PK_S_ANS_EXIT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_EXIT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_EXIT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
    }

    public class PK_C_REQ_REGISTER : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _charName);
            PacketUtil.Encoding(_stream, _password);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _charName = PacketUtil.Decodingstring(packet, ref offset);
            _password = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_REGISTER;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_REGISTER;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public string _charName;
        public string _password;
    }

    public class PK_S_ANS_REGISTER_FAIL : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_REGISTER_FAIL;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_REGISTER_FAIL;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public string _charName;
    }

    public class PK_S_ANS_REGISTER_SUCCESS : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_REGISTER_SUCCESS;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_REGISTER_SUCCESS;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }
    }

    public class PK_C_REQ_LOGIN : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _charName);
            PacketUtil.Encoding(_stream, _password);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _charName = PacketUtil.Decodingstring(packet, ref offset);
            _password = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_LOGIN;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_LOGIN;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public string _charName;
        public string _password;
    }

    public class PK_S_ANS_LOGIN_FAIL : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_LOGIN_FAIL;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_LOGIN_FAIL;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public string _charName;
    }

    public class PK_S_ANS_LOGIN_SUCCESS : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_LOGIN_SUCCESS;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_LOGIN_SUCCESS;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
        public string _charName;
    }

    public class PK_C_NOTIFY_LOGIN_CLIENT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_NOTIFY_LOGIN_CLIENT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_NOTIFY_LOGIN_CLIENT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
        public string _charName;
    }

    public class PK_S_NOTIFY_LOGIN_CLIENT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _check);
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _check = PacketUtil.DecodingBool(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_NOTIFY_LOGIN_CLIENT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_NOTIFY_LOGIN_CLIENT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public bool _check;
        public UInt16 _uid;
        public string _charName;
    }

    public class PK_C_REQ_CONNECT_ROOM : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_CONNECT_ROOM;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_CONNECT_ROOM;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public Byte _roomNumber;
        public UInt16 _uid;
        public string _charName;
    }

    public class PK_S_ANS_CONNECT_ROOM : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_CONNECT_ROOM;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_CONNECT_ROOM;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public Byte _roomNumber;
        public UInt16 _uid;
        public string _charName;
    }

    public class PK_S_ANS_CONNECT_FAIL_ROOM : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_CONNECT_FAIL_ROOM;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_CONNECT_FAIL_ROOM;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
    }

    public class PK_C_NOTIFY_CONNECT_ROOM_CLIENT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_NOTIFY_CONNECT_ROOM_CLIENT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_NOTIFY_CONNECT_ROOM_CLIENT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public Byte _roomNumber;
        public UInt16 _uid;
        public string _charName;
    }

    public class PK_S_NOTIFY_CONNECT_ROOM_CLIENT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _check);
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _check = PacketUtil.DecodingBool(packet, ref offset);
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_NOTIFY_CONNECT_ROOM_CLIENT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_NOTIFY_CONNECT_ROOM_CLIENT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public bool _check;
        public Byte _roomNumber;
        public UInt16 _uid;
        public string _charName;
    }

    // player move
    public class PK_C_REQ_PLAYER_MOVE : Packet, PacketInterface
    { 
		void PacketInterface.Encoding()
		{
			PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
            PacketUtil.Encoding(_stream, _Xpos);
            PacketUtil.Encoding(_stream, _Ypos);
            PacketUtil.Encoding(_stream, _Zpos);
            PacketUtil.Encoding(_stream, _Xrot);
            PacketUtil.Encoding(_stream, _Yrot);
            PacketUtil.Encoding(_stream, _Zrot);
        }

		void PacketInterface.Decoding(byte[] packet, ref int offset)
		{
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
			_Xpos = PacketUtil.Decodingfloat(packet, ref offset);
			_Ypos = PacketUtil.Decodingfloat(packet, ref offset);
			_Zpos = PacketUtil.Decodingfloat(packet, ref offset);
            _Xrot = PacketUtil.Decodingfloat(packet, ref offset);
            _Yrot = PacketUtil.Decodingfloat(packet, ref offset);
            _Zrot = PacketUtil.Decodingfloat(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_PLAYER_MOVE;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_PLAYER_MOVE;
        }

        MemoryStream PacketInterface.GetStream()
		{
			return _stream;
		}

        public Byte _roomNumber;

        public UInt16 _uid;

        // 플레이어 이름
        public string _charName;
        
        // 좌표 값
		public Single _Xpos;
		public Single _Ypos;
		public Single _Zpos;

        // 회전 값
        public Single _Xrot;
        public Single _Yrot;
        public Single _Zrot;
	}

	public class PK_S_ANS_PLAYER_MOVE : Packet, PacketInterface
	{
		void PacketInterface.Encoding()
		{
			PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
            PacketUtil.Encoding(_stream, _Xpos);
			PacketUtil.Encoding(_stream, _Ypos);
			PacketUtil.Encoding(_stream, _Zpos);
            PacketUtil.Encoding(_stream, _Xrot);
            PacketUtil.Encoding(_stream, _Yrot);
            PacketUtil.Encoding(_stream, _Zrot);
        }

		void PacketInterface.Decoding(byte[] packet, ref int offset)
		{
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
			_Xpos = PacketUtil.Decodingfloat(packet, ref offset);
			_Ypos = PacketUtil.Decodingfloat(packet, ref offset);
			_Zpos = PacketUtil.Decodingfloat(packet, ref offset);
            _Xrot = PacketUtil.Decodingfloat(packet, ref offset);
            _Yrot = PacketUtil.Decodingfloat(packet, ref offset);
            _Zrot = PacketUtil.Decodingfloat(packet, ref offset);
        }

        Byte PacketInterface.type()
		{
            return (Byte)PacketType.E_S_ANS_PLAYER_MOVE;
		}

        Byte type() 
        {
            return (Byte)PacketType.E_S_ANS_PLAYER_MOVE; 
        }

        MemoryStream PacketInterface.GetStream()
		{
			return _stream;
		}

        public UInt16 _uid;
        public string _charName;
        
		public Single _Xpos;
		public Single _Ypos;
		public Single _Zpos;

        public Single _Xrot;
        public Single _Yrot;
        public Single _Zrot;
    }

    public class PK_C_REQ_BULLET_SHOOT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_BULLET_SHOOT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_BULLET_SHOOT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public Byte _roomNumber;
        public UInt16 _uid;
    }

    public class PK_S_ANS_BULLET_SHOOT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_BULLET_SHOOT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_BULLET_SHOOT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
    }

    public class PK_C_REQ_COLLISION_CHECK : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_COLLISION_CHECK;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_COLLISION_CHECK;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public Byte _roomNumber;
        public UInt16 _uid;
     
    }

    public class PK_S_ANS_COLLISION_CHECK : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_COLLISION_CHECK;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_COLLISION_CHECK;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
    }

    public class PK_C_REQ_CHAT_INPUT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _charName);
            PacketUtil.Encoding(_stream, _text);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
            _text = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_CHAT_INPUT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_CHAT_INPUT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public Byte _roomNumber;
        public string _charName;
        public string _text;
    }

    public class PK_S_ANS_CHAT_OUTPUT : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _charName);
            PacketUtil.Encoding(_stream, _text);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _charName = PacketUtil.Decodingstring(packet, ref offset);
            _text = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_CHAT_OUTPUT;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_CHAT_OUTPUT;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public string _charName;
        public string _text;
    }

    public class PK_C_REQ_EXIT_ROOM : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _roomNumber);
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _roomNumber = PacketUtil.DecodingByte(packet, ref offset);
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_C_REQ_EXIT_ROOM;
        }

        Byte type()
        {
            return (Byte)PacketType.E_C_REQ_EXIT_ROOM;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public Byte _roomNumber;
        public UInt16 _uid;
        public string _charName;
    }

    public class PK_S_ANS_EXIT_ROOM : Packet, PacketInterface
    {
        void PacketInterface.Encoding()
        {
            PacketUtil.EncodingHeader(_stream, this.type());
            PacketUtil.Encoding(_stream, _uid);
            PacketUtil.Encoding(_stream, _charName);
        }

        void PacketInterface.Decoding(byte[] packet, ref int offset)
        {
            _uid = PacketUtil.DecodingUInt16(packet, ref offset);
            _charName = PacketUtil.Decodingstring(packet, ref offset);
        }

        Byte PacketInterface.type()
        {
            return (Byte)PacketType.E_S_ANS_EXIT_ROOM;
        }

        Byte type()
        {
            return (Byte)PacketType.E_S_ANS_EXIT_ROOM;
        }

        MemoryStream PacketInterface.GetStream()
        {
            return _stream;
        }

        public UInt16 _uid;
        public string _charName;
    }
}
