using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    public class ShortcutObject : Shortcut
    {
        public new const ushort ProtocolId = 367;

        public override ushort TypeID => ProtocolId;

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