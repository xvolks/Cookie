using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class ChangeThemeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6639;

        public ChangeThemeRequestMessage(sbyte theme)
        {
            Theme = theme;
        }

        public ChangeThemeRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte Theme { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Theme);
        }

        public override void Deserialize(IDataReader reader)
        {
            Theme = reader.ReadSByte();
        }
    }
}