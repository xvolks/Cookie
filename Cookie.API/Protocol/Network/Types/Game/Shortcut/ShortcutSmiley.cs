using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Shortcut
{
    public class ShortcutSmiley : Shortcut
    {
        public new const ushort ProtocolId = 388;

        public ShortcutSmiley(ushort smileyId)
        {
            SmileyId = smileyId;
        }

        public ShortcutSmiley()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort SmileyId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SmileyId = reader.ReadVarUhShort();
        }
    }
}