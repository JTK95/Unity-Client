using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System;

namespace Client
{
    public interface PacketInterface
    {
        void Encoding();
        void Decoding(byte[] packet, ref int offset); // ref =  int& offset

        Byte type();
        MemoryStream GetStream();
    }

    public class Packet
    {
        protected MemoryStream _stream = new MemoryStream();

        ~Packet()
        {
            _stream = null;
        }
    }
}