using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismsListRegisterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6441;

        public override ushort MessageID => ProtocolId;

        public sbyte Listen { get; set; }
        public PrismsListRegisterMessage() { }

        public PrismsListRegisterMessage( sbyte Listen ){
            this.Listen = Listen;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Listen);
        }

        public override void Deserialize(IDataReader reader)
        {
            Listen = reader.ReadSByte();
        }
    }
}
