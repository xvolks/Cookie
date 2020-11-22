using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyNameUpdateMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6502;

        public override ushort MessageID => ProtocolId;

        public string PartyName { get; set; }
        public PartyNameUpdateMessage() { }

        public PartyNameUpdateMessage( string PartyName ){
            this.PartyName = PartyName;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyName = reader.ReadUTF();
        }
    }
}
