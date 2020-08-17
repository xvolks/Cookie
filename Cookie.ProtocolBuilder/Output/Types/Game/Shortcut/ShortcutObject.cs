namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutObject : Shortcut
    {
        public new const ushort ProtocolId = 367;
        public override ushort TypeID => ProtocolId;

        public ShortcutObject() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
