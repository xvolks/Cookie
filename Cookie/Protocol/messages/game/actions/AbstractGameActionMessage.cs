using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AbstractGameActionMessage : NetworkMessage
    {
        public const uint ProtocolId = 1000;
        public override uint MessageID { get { return ProtocolId; } }

        public short ActionId = 0;
        public double SourceId = 0;

        public AbstractGameActionMessage()
        {
        }

        public AbstractGameActionMessage(
            short actionId,
            double sourceId
        )
        {
            ActionId = actionId;
            SourceId = sourceId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ActionId);
            writer.WriteDouble(SourceId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ActionId = reader.ReadVarShort();
            SourceId = reader.ReadDouble();
        }
    }
}