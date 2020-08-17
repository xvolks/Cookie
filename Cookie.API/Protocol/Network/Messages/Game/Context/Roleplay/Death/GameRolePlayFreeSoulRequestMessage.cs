namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Death
{
    using Utils.IO;

    public class GameRolePlayFreeSoulRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 745;
        public override ushort MessageID => ProtocolId;

        public GameRolePlayFreeSoulRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
