using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6041;

        public PrismUseRequestMessage(byte moduleToUse)
        {
            ModuleToUse = moduleToUse;
        }

        public PrismUseRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte ModuleToUse { get; set; }

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