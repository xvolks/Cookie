using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class PortalDialogCreationMessage : NpcDialogCreationMessage
    {
        public new const ushort ProtocolId = 6737;

        public PortalDialogCreationMessage(int type)
        {
            Type = type;
        }

        public PortalDialogCreationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Type = reader.ReadInt();
        }
    }
}