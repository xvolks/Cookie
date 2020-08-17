using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class PortalUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6492;

        public PortalUseRequestMessage(uint portalId)
        {
            PortalId = portalId;
        }

        public PortalUseRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint PortalId { get; set; }

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