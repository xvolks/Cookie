using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HelloConnectMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3;

        public override ushort MessageID => ProtocolId;

        public string Salt { get; set; }
        public List<sbyte> Key { get; set; }
        public HelloConnectMessage() { }

        public HelloConnectMessage( string Salt, List<sbyte> Key ){
            this.Salt = Salt;
            this.Key = Key;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Salt);
			writer.WriteVarInt((int)Key.Count);
			foreach (var x in Key)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Salt = reader.ReadUTF();
            var KeyCount = reader.ReadVarInt();
            Key = new List<sbyte>();
            for (var i = 0; i < KeyCount; i++)
            {
                Key.Add(reader.ReadSByte());
            }
        }
    }
}
