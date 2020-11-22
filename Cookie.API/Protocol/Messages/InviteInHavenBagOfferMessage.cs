using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InviteInHavenBagOfferMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6643;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations HostInformations { get; set; }
        public int TimeLeftBeforeCancel { get; set; }
        public InviteInHavenBagOfferMessage() { }

        public InviteInHavenBagOfferMessage( CharacterMinimalInformations HostInformations, int TimeLeftBeforeCancel ){
            this.HostInformations = HostInformations;
            this.TimeLeftBeforeCancel = TimeLeftBeforeCancel;
        }

        public override void Serialize(IDataWriter writer)
        {
            HostInformations.Serialize(writer);
            writer.WriteVarInt(TimeLeftBeforeCancel);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostInformations = new CharacterMinimalInformations();
            HostInformations.Deserialize(reader);
            TimeLeftBeforeCancel = reader.ReadVarInt();
        }
    }
}
