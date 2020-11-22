using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachKickResponseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6789;

        public override ushort MessageID => ProtocolId;

        public CharacterMinimalInformations Target { get; set; }
        public bool Kicked { get; set; }
        public BreachKickResponseMessage() { }

        public BreachKickResponseMessage( CharacterMinimalInformations Target, bool Kicked ){
            this.Target = Target;
            this.Kicked = Kicked;
        }

        public override void Serialize(IDataWriter writer)
        {
            Target.Serialize(writer);
            writer.WriteBoolean(Kicked);
        }

        public override void Deserialize(IDataReader reader)
        {
            Target = new CharacterMinimalInformations();
            Target.Deserialize(reader);
            Kicked = reader.ReadBoolean();
        }
    }
}
