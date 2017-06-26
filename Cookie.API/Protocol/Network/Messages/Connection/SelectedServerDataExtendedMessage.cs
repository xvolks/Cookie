using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
    {
        public new const uint ProtocolId = 6469;

        public List<ushort> ServerIds;

        public SelectedServerDataExtendedMessage()
        {
        }

        public SelectedServerDataExtendedMessage(List<ushort> serverIds)
        {
            ServerIds = serverIds;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) ServerIds.Count);
            for (var i = 0; i < ServerIds.Count; i++)
                writer.WriteVarUhShort(ServerIds[i]);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var length = reader.ReadUShort();
            ServerIds = new List<ushort>();
            for (var i = 0; i < length; i++)
                ServerIds.Add(reader.ReadVarUhShort());
        }
    }
}