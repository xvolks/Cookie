using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountHarnessColorsUpdateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6697;

        public MountHarnessColorsUpdateRequestMessage(bool useHarnessColors)
        {
            UseHarnessColors = useHarnessColors;
        }

        public MountHarnessColorsUpdateRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool UseHarnessColors { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(UseHarnessColors);
        }

        public override void Deserialize(IDataReader reader)
        {
            UseHarnessColors = reader.ReadBoolean();
        }
    }
}