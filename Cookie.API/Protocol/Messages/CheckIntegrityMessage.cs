using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CheckIntegrityMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6372;

        public override ushort MessageID => ProtocolId;

        public List<sbyte> Data { get; set; }
        public CheckIntegrityMessage() { }

        public CheckIntegrityMessage( List<sbyte> Data ){
            this.Data = Data;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteVarInt((int)Data.Count);
			foreach (var x in Data)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var DataCount = reader.ReadVarInt();
            Data = new List<sbyte>();
            for (var i = 0; i < DataCount; i++)
            {
                Data.Add(reader.ReadSByte());
            }
        }
    }
}
