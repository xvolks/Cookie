using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Pvp
{
    public class SetEnableAVARequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6443;

        public SetEnableAVARequestMessage(bool enable)
        {
            Enable = enable;
        }

        public SetEnableAVARequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}