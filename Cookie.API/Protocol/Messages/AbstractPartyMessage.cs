using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AbstractPartyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6274;

        public override ushort MessageID => ProtocolId;

        public uint PartyId { get; set; }
        public AbstractPartyMessage() { }

        public AbstractPartyMessage( uint PartyId ){
            this.PartyId = PartyId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(PartyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PartyId = reader.ReadVarUhInt();
        }
    }
}
