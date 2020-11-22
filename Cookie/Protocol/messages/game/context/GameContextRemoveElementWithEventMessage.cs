using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
    {
        public new const uint ProtocolId = 6412;
        public override uint MessageID { get { return ProtocolId; } }

        public byte ElementEventId = 0;

        public GameContextRemoveElementWithEventMessage(): base()
        {
        }

        public GameContextRemoveElementWithEventMessage(
            double id_,
            byte elementEventId
        ): base(
            id_
        )
        {
            ElementEventId = elementEventId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(ElementEventId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ElementEventId = reader.ReadByte();
        }
    }
}