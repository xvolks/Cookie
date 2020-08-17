using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Death
{
    public class WarnOnPermaDeathMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6512;

        public WarnOnPermaDeathMessage(bool enable)
        {
            Enable = enable;
        }

        public WarnOnPermaDeathMessage()
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