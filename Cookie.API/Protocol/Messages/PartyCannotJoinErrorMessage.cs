using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyCannotJoinErrorMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5583;

        public override ushort MessageID => ProtocolId;

        public sbyte Reason { get; set; }
        public PartyCannotJoinErrorMessage() { }

        public PartyCannotJoinErrorMessage( sbyte Reason ){
            this.Reason = Reason;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadSByte();
        }
    }
}
