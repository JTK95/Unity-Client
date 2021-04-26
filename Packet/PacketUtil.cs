using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

namespace Client
{
    //---------------------------------------------------------------------------
	// PacketUtil class (패킷의 구성 성분을 만든다)
    //---------------------------------------------------------------------------
	public static class PacketUtil
	{
		//-------------------------------------------------------------------------------------
		// encoding 부분
		// Memorystream 에서 write 가 성공하면 알아서 offset 변경되기 때문에 0 으로 해도 상관없다
		//-------------------------------------------------------------------------------------
		public static void EncodingHeader(MemoryStream stream, Byte headerType)
        {
			PacketUtil.Encoding(stream, headerType);
        }

		public static void Encoding(MemoryStream stream, Byte value)
        {
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(Byte));
        }

		public static void Encoding(MemoryStream stream, bool value)
		{
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(bool));
		}

		public static void Encoding(MemoryStream stream, Char value)
        {
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(Char));
        }

		public static void Encoding(MemoryStream stream, float value)
        {
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(float));
        }

		public static void Encoding(MemoryStream stream, Int16 value)
        {
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(Int16));
        }

		public static void Encoding(MemoryStream stream, UInt16 value)
		{
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(UInt16));
		}

		public static void Encoding(MemoryStream stream, Int32 value)
		{
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(Int32));
		}

		public static void Encoding(MemoryStream stream, UInt32 value)
		{
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(UInt32));
		}

		public static void Encoding(MemoryStream stream, Int64 value)
		{
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(Int64));
		}

		public static void Encoding(MemoryStream stream, UInt64 value)
		{
			stream.Write(BitConverter.GetBytes(value), 0, sizeof(UInt64));
		}

		public static void Encoding(MemoryStream stream, string str)
        {
			PacketUtil.Encoding(stream, (Int32)str.Length);
			stream.Write(System.Text.Encoding.UTF8.GetBytes(str), 0, str.Length);
		}

		//------------------------------------------------------------------------
		// decoding 부분
		//------------------------------------------------------------------------
		public static Int32 DecodingPacketLen(Byte[] data, ref Int32 offset)
        {
			return PacketUtil.DecodingInt32(data, ref offset);
        }

		public static Byte DecodingPacketType(Byte[] data, ref Int32 offset)
        {
			return PacketUtil.DecodingByte(data, ref offset);
		}

		public static bool DecodingBool(Byte[] data, ref Int32 offset)
        {
			bool val = BitConverter.ToBoolean(data, offset);
			offset += sizeof(bool);

			return val;
        }

		public static Byte DecodingByte(Byte[] data, ref Int32 offset)
        {
			Byte val = data[offset];
			offset += sizeof(Byte);

			return val;
        }

		public static Char DecodingInt8(Byte[] data, ref Int32 offset)
        {
			Char val = BitConverter.ToChar(data, offset);
			offset += sizeof(Char);

			return val;
        }

		public static Single Decodingfloat(Byte[] data, ref Int32 offset)
		{
			Single val = BitConverter.ToSingle(data, offset);
			offset += sizeof(Single);

			return val;
		}

		public static Int16 DecodingInt16(Byte[] data, ref Int32 offset)
        {
			Int16 val = BitConverter.ToInt16(data, offset);
			offset += sizeof(Int16);

			return val;
        }

		public static UInt16 DecodingUInt16(Byte[] data, ref Int32 offset)
		{
			UInt16 val = BitConverter.ToUInt16(data, offset);
			offset += sizeof(UInt16);

			return val;
		}

		public static Int32 DecodingInt32(Byte[] data, ref Int32 offset)
		{
			Int32 val = BitConverter.ToInt32(data, offset);
			offset += sizeof(Int32);

			return val;
		}

		public static UInt32 DecodingUInt32(Byte[] data, ref Int32 offset)
		{
			UInt32 val = BitConverter.ToUInt32(data, offset);
			offset += sizeof(UInt16);

			return val;
		}

		public static Int64 DecodingInt64(Byte[] data, ref Int32 offset)
		{
			Int64 val = BitConverter.ToInt64(data, offset);
			offset += sizeof(Int64);

			return val;
		}

		public static UInt64 DecodingUInt64(Byte[] data, ref Int32 offset)
		{
			UInt64 val = BitConverter.ToUInt64(data, offset);
			offset += sizeof(UInt64);

			return val;
		}

		public static string Decodingstring(Byte[] data, ref Int32 offset)
        {
			Int32 strLen = PacketUtil.DecodingInt32(data, ref offset);
			string str = System.Text.Encoding.ASCII.GetString(data, offset, strLen);
			offset += strLen;

			return str;
        }

		public static PacketInterface PacketAnalyzer(Byte[] packetByte)
		{
			Int32 offset = 0;
			Byte packetType = PacketUtil.DecodingPacketType(packetByte, ref offset);
			//Debug.Log("PACKET TYPE: " + packetType);
			PacketInterface packet = PacketFactory.GetPacket(packetType);
			if (packet == null)
			{
				Debug.Log("shoot!");
				return null;
			}

			// 데이터가 있으면 decoding 해서 넘기기
			if (offset < packetByte.Length)
			{
				packet.Decoding(packetByte, ref offset);
			}
			return packet;
		}
	}
}

