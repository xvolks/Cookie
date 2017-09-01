namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest
{
    using Utils.IO;

    public class QuestListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5623;
        public override ushort MessageID => ProtocolId;

        public QuestListRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
