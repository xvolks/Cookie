using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class CheckIntegrityMessage : NetworkMessage
    {
        public const uint ProtocolId = 6372;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> Data;

        public CheckIntegrityMessage()
        {
        }

        public CheckIntegrityMessage(
            List<byte> data
        )
        {
            Data = data;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt((int)Data.Count());
            foreach (var current in Data)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countData = reader.ReadVarInt();
            Data = new List<byte>();
            for (int i = 0; i < countData; i++)
            {
                Data.Add(reader.ReadByte());
            }
        }
    }
}