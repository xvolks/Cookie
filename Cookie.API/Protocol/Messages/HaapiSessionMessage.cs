using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HaapiSessionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6769;

        public override ushort MessageID => ProtocolId;

        public string Key { get; set; }
        public sbyte Type { get; set; }
        public HaapiSessionMessage() { }

        public HaapiSessionMessage( string Key, sbyte Type ){
            this.Key = Key;
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Key);
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Key = reader.ReadUTF();
            Type = reader.ReadSByte();
        }
    }
}
