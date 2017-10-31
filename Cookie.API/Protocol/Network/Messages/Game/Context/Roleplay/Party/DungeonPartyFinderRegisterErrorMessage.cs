namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class DungeonPartyFinderRegisterErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6243;
        public override ushort MessageID => ProtocolId;

        public DungeonPartyFinderRegisterErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
