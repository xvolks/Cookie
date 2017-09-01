using System;
using Cookie.API.Messages;
using Cookie.API.Network;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol
{
    public abstract class NetworkMessage : Message
    {
        public abstract ushort MessageID { get; }

        public ListenerEntry Destinations { get; set; }

        public ListenerEntry From { get; set; }

        public abstract void Serialize(IDataWriter writer);
        public abstract void Deserialize(IDataReader reader);

        public override void BlockProgression()
        {
            Canceled = true;
            Destinations = ListenerEntry.Local;
        }

        public void BlockNetworkSend()
        {
            Destinations = ListenerEntry.Local;
        }

        private static byte ComputeTypeLen(int param1)
        {
            byte num;
            if (param1 > 65535)
                num = 3;
            else if (param1 <= 255)
                num = (byte) (param1 <= 0 ? 0 : 1);
            else
                num = 2;
            return num;
        }

        public void Pack(IDataWriter writer)
        {
            Serialize(writer);
            WritePacket(writer);
        }

        private static uint SubComputeStaticHeader(uint id, byte typeLen)
        {
            return (id << 2) | typeLen;
        }

        public override string ToString()
        {
            return GetType().Name;
        }

        public void Unpack(IDataReader reader)
        {
            Deserialize(reader);
        }

        private void WritePacket(IDataWriter writer)
        {
            var data = writer.Data;
            writer.Clear();
            var num = ComputeTypeLen(data.Length);
            var num1 = SubComputeStaticHeader(MessageID, num);
            writer.WriteShort((short) num1);
            writer.WriteUInt(MessageUtils.InstanceId++);
            switch (num)
            {
                case 0:
                    break;
                case 1:
                    writer.WriteByte((byte) data.Length);
                    break;
                case 2:
                    writer.WriteShort((short) data.Length);
                    break;
                case 3:
                    writer.WriteByte((byte) ((data.Length >> 16) & 255));
                    writer.WriteShort((short) (data.Length & 65535));
                    break;
                default:
                    throw new Exception("Packet's length can't be encoded on 4 or more bytes");
            }
            writer.WriteBytes(data);
        }
    }
}