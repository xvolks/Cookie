namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Death
{
    using Utils.IO;

    public class GameRolePlayGameOverMessage : NetworkMessage
    {
        public const ushort ProtocolId = 746;
        public override ushort MessageID => ProtocolId;

        public GameRolePlayGameOverMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
