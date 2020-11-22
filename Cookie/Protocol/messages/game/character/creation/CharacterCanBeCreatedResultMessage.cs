using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterCanBeCreatedResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 6733;
        public override uint MessageID { get { return ProtocolId; } }

        public bool YesYouCan = false;

        public CharacterCanBeCreatedResultMessage()
        {
        }

        public CharacterCanBeCreatedResultMessage(
            bool yesYouCan
        )
        {
            YesYouCan = yesYouCan;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(YesYouCan);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            YesYouCan = reader.ReadBoolean();
        }
    }
}