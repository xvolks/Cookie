namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class DungeonPartyFinderAvailableDungeonsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6240;
        public override ushort MessageID => ProtocolId;

        public DungeonPartyFinderAvailableDungeonsRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
