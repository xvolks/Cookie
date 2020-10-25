using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ShortcutObject : Shortcut
    {
        public new const short ProtocolId = 367;
        public override short TypeId { get { return ProtocolId; } }

        public ShortcutObject(): base()
        {
        }

        public ShortcutObject(
            byte slot
        ): base(
            slot
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}