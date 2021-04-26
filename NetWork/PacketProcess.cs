using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    internal abstract class PacketProcess 
    {
        public abstract void run(PacketInterface packet);

        public bool defaultRun(PacketInterface packet)
        {
            PacketType type = (PacketType)packet.type();

            // 공통 처리 패킷에 대한 정의
            
            return false;
        }
    }
}
