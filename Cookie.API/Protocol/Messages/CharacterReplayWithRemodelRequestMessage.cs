using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterReplayWithRemodelRequestMessage : CharacterReplayRequestMessage
    {
        public new const ushort ProtocolId = 6551;

        public override ushort MessageID => ProtocolId;

        public RemodelingInformation Remodel { get; set; }
        public CharacterReplayWithRemodelRequestMessage() { }

        public CharacterReplayWithRemodelRequestMessage( RemodelingInformation Remodel ){
            this.Remodel = Remodel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Remodel.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Remodel = new RemodelingInformation();
            Remodel.Deserialize(reader);
        }
    }
}
