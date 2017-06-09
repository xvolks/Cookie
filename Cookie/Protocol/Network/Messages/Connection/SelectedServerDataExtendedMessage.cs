using Cookie.IO;
using System.Collections.Generic;

namespace Cookie.Protocol.Network.Messages.Connection
{
    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        public new const uint ProtocolId = 6469;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ushort> ServerIds;

        public SelectedServerDataExtendedMessage() { }

        public SelectedServerDataExtendedMessage(List<ushort> serverIds)
        {
            ServerIds = serverIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ServerIds.Count);
            for (int i = 0; i < ServerIds.Count; i++)
            {
                writer.WriteVarUhShort(ServerIds[i]);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ushort length = reader.ReadUShort();
            ServerIds = new List<ushort>();
            for (int i = 0; i < length; i++)
            {
                ServerIds.Add(reader.ReadVarUhShort());
            }
        }
    }
}
