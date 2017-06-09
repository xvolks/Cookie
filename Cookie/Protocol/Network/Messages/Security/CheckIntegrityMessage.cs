using Cookie.IO;
using System.Collections.Generic;

namespace Cookie.Protocol.Network.Messages.Security
{
    public class CheckIntegrityMessage : NetworkMessage
    {
        public const uint ProtocolId = 6372;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> Data { get; set; }

        public CheckIntegrityMessage() { }

        public CheckIntegrityMessage(List<int> data)
        {
            Data = data;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Data.Count);
            for (int i = 0; i < Data.Count; i++)
            {
                writer.WriteByte((byte)Data[i]);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            int length = reader.ReadVarInt();
            Data = new List<int>();
            for (int i = 0; i < length; i++)
            {
                Data.Add(reader.ReadByte());
            }
        }
    }
}
