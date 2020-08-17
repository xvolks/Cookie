using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Creation
{
    public class CharacterCanBeCreatedResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6733;

        public CharacterCanBeCreatedResultMessage(bool yesYouCan)
        {
            YesYouCan = yesYouCan;
        }

        public CharacterCanBeCreatedResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool YesYouCan { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(YesYouCan);
        }

        public override void Deserialize(IDataReader reader)
        {
            YesYouCan = reader.ReadBoolean();
        }
    }
}