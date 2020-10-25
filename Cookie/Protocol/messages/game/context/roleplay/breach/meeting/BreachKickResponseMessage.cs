using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachKickResponseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6789;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterMinimalInformations Target;
        public bool Kicked = false;

        public BreachKickResponseMessage()
        {
        }

        public BreachKickResponseMessage(
            CharacterMinimalInformations target,
            bool kicked
        )
        {
            Target = target;
            Kicked = kicked;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Target.Serialize(writer);
            writer.WriteBoolean(Kicked);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Target = new CharacterMinimalInformations();
            Target.Deserialize(reader);
            Kicked = reader.ReadBoolean();
        }
    }
}