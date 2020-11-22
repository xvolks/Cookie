using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterFirstSelectionMessage : CharacterSelectionMessage
    {
        public new const ushort ProtocolId = 6084;

        public override ushort MessageID => ProtocolId;

        public bool DoTutorial { get; set; }
        public CharacterFirstSelectionMessage() { }

        public CharacterFirstSelectionMessage( bool DoTutorial ){
            this.DoTutorial = DoTutorial;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(DoTutorial);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DoTutorial = reader.ReadBoolean();
        }
    }
}
