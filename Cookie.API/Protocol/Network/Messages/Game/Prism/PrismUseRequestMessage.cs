namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    using Utils.IO;

    public class PrismUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6041;
        public override ushort MessageID => ProtocolId;
        public byte ModuleToUse { get; set; }

        public PrismUseRequestMessage(byte moduleToUse)
        {
            ModuleToUse = moduleToUse;
        }

        public PrismUseRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ModuleToUse);
        }

        public override void Deserialize(IDataReader reader)
        {
            ModuleToUse = reader.ReadByte();
        }

    }
}
