using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace Client
{
	public static class PacketFactory
	{
		public static PacketInterface GetPacket(Byte packetType)
        {
			switch((PacketType)packetType)
            {
                case PacketType.E_C_REQ_EXIT:
                    return new PK_C_REQ_EXIT();
                case PacketType.E_S_ANS_EXIT:
                    return new PK_S_ANS_EXIT();
                case PacketType.E_C_REQ_REGISTER:
                    return new PK_C_REQ_REGISTER();
                case PacketType.E_S_ANS_REGISTER_FAIL:
                    return new PK_S_ANS_REGISTER_FAIL();
                case PacketType.E_C_REQ_LOGIN:
                    return new PK_C_REQ_LOGIN();
                case PacketType.E_S_ANS_LOGIN_FAIL:
                    return new PK_S_ANS_LOGIN_FAIL();
                case PacketType.E_S_ANS_LOGIN_SUCCESS:
                    return new PK_S_ANS_LOGIN_SUCCESS();
                case PacketType.E_C_NOTIFY_LOGIN_CLIENT:
                    return new PK_C_NOTIFY_LOGIN_CLIENT();
                case PacketType.E_S_NOTIFY_LOGIN_CLIENT:
                    return new PK_S_NOTIFY_LOGIN_CLIENT();
                case PacketType.E_C_REQ_CONNECT_ROOM:
                    return new PK_C_REQ_CONNECT_ROOM();
                case PacketType.E_S_ANS_CONNECT_ROOM:
                    return new PK_S_ANS_CONNECT_ROOM();
                case PacketType.E_C_NOTIFY_CONNECT_ROOM_CLIENT:
                    return new PK_C_NOTIFY_CONNECT_ROOM_CLIENT();
                case PacketType.E_S_ANS_CONNECT_FAIL_ROOM:
                    return new PK_S_ANS_CONNECT_FAIL_ROOM();
                case PacketType.E_S_NOTIFY_CONNECT_ROOM_CLIENT:
                    return new PK_S_NOTIFY_CONNECT_ROOM_CLIENT();
                case PacketType.E_C_REQ_PLAYER_MOVE:
					return new PK_C_REQ_PLAYER_MOVE();
				case PacketType.E_S_ANS_PLAYER_MOVE:
					return new PK_S_ANS_PLAYER_MOVE();
                case PacketType.E_C_REQ_BULLET_SHOOT:
                    return new PK_C_REQ_BULLET_SHOOT();
                case PacketType.E_S_ANS_BULLET_SHOOT:
                    return new PK_S_ANS_BULLET_SHOOT();
                case PacketType.E_C_REQ_COLLISION_CHECK:
                    return new PK_C_REQ_COLLISION_CHECK();
                case PacketType.E_S_ANS_COLLISION_CHECK:
                    return new PK_S_ANS_COLLISION_CHECK();
                case PacketType.E_C_REQ_CHAT_INPUT:
                    return new PK_C_REQ_CHAT_INPUT();
                case PacketType.E_S_ANS_CHAT_OUTPUT:
                    return new PK_S_ANS_CHAT_OUTPUT();
                case PacketType.E_C_REQ_EXIT_ROOM:
                    return new PK_C_REQ_EXIT_ROOM();
                case PacketType.E_S_ANS_EXIT_ROOM:
                    return new PK_S_ANS_EXIT_ROOM();
            }

			return null;
        }
	}
}
