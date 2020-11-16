using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PortalDialogCreationMessage : NpcDialogCreationMessage
    {
        public new const uint ProtocolId = 6737;
        public override uint MessageID { get { return ProtocolId; } }

        public int Type = 0;

        public PortalDialogCreationMessage(): base()
        {
        }

        public PortalDialogCreationMessage(
            double mapId,
            int npcId,
            int type
        ): base(
            mapId,
            npcId
        )
        {
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Type);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Type = reader.ReadInt();
        }
    }
}