using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Job
{
    public class JobAllowMultiCraftRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5748;

        public JobAllowMultiCraftRequestMessage(bool enabled)
        {
            Enabled = enabled;
        }

        public JobAllowMultiCraftRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Enabled { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enabled = reader.ReadBoolean();
        }
    }
}