using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ShortcutSmiley : Shortcut
    {
        public new const short ProtocolId = 388;
        public override short TypeId { get { return ProtocolId; } }

        public short SmileyId = 0;

        public ShortcutSmiley(): base()
        {
        }

        public ShortcutSmiley(
            byte slot,
            short smileyId
        ): base(
            slot
        )
        {
            SmileyId = smileyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(SmileyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SmileyId = reader.ReadVarShort();
        }
    }
}