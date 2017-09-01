using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountRidingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5967;

        public MountRidingMessage(bool isRiding)
        {
            IsRiding = isRiding;
        }

        public MountRidingMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool IsRiding { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsRiding);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsRiding = reader.ReadBoolean();
        }
    }
}