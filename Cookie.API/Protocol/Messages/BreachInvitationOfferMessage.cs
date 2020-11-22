using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachInvitationOfferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6805;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations Host { get; set; }
        public uint TimeLeftBeforeCancel { get; set; }
        public BreachInvitationOfferMessage() { }

        public BreachInvitationOfferMessage( CharacterMinimalInformations Host, uint TimeLeftBeforeCancel ){
            this.Host = Host;
            this.TimeLeftBeforeCancel = TimeLeftBeforeCancel;
        }

        public override void Serialize(IDataWriter writer)
        {
            Host.Serialize(writer);
            writer.WriteVarUhInt(TimeLeftBeforeCancel);
        }

        public override void Deserialize(IDataReader reader)
        {
            Host = new CharacterMinimalInformations();
            Host.Deserialize(reader);
            TimeLeftBeforeCancel = reader.ReadVarUhInt();
        }
    }
}
