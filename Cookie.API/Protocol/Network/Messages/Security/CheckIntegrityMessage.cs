using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Security
{
    public class CheckIntegrityMessage : NetworkMessage
    {
        public const uint ProtocolId = 6372;

        public CheckIntegrityMessage()
        {
        }

        public CheckIntegrityMessage(List<int> data)
        {
            Data = data;
        }

        public override uint MessageID => ProtocolId;

        public List<int> Data { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(Data.Count);
            for (var i = 0; i < Data.Count; i++)
                writer.WriteByte((byte) Data[i]);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var length = reader.ReadVarInt();
            Data = new List<int>();
            for (var i = 0; i < length; i++)
                Data.Add(reader.ReadByte());
        }
    }
}