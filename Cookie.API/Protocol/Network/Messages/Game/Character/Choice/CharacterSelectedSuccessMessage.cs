using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterSelectedSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 153;

        public CharacterSelectedSuccessMessage(CharacterBaseInformations infos, bool isCollectingStats)
        {
            Infos = infos;
            IsCollectingStats = isCollectingStats;
        }

        public CharacterSelectedSuccessMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public CharacterBaseInformations Infos { get; set; }
        public bool IsCollectingStats { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Infos.Serialize(writer);
            writer.WriteBoolean(IsCollectingStats);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = new CharacterBaseInformations();
            Infos.Deserialize(reader);
            IsCollectingStats = reader.ReadBoolean();
        }
    }
}