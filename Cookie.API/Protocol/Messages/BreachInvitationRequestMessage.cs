using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachInvitationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6794;

        public override ushort MessageID => ProtocolId;

        public ulong Guest { get; set; }
        public BreachInvitationRequestMessage() { }

        public BreachInvitationRequestMessage( ulong Guest ){
            this.Guest = Guest;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Guest);
        }

        public override void Deserialize(IDataReader reader)
        {
            Guest = reader.ReadVarUhLong();
        }
    }
}
