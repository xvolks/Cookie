namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class PortalUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6492;
        public override ushort MessageID => ProtocolId;
        public uint PortalId { get; set; }

        public PortalUseRequestMessage(uint portalId)
        {
            PortalId = portalId;
        }

        public PortalUseRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(PortalId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PortalId = reader.ReadVarUhInt();
        }

    }
}
