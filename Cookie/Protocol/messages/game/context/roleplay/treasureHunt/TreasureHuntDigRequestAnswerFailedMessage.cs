using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntDigRequestAnswerFailedMessage : TreasureHuntDigRequestAnswerMessage
    {
        public new const uint ProtocolId = 6509;
        public override uint MessageID { get { return ProtocolId; } }

        public byte WrongFlagCount = 0;

        public TreasureHuntDigRequestAnswerFailedMessage(): base()
        {
        }

        public TreasureHuntDigRequestAnswerFailedMessage(
            byte questType,
            byte result,
            byte wrongFlagCount
        ): base(
            questType,
            result
        )
        {
            WrongFlagCount = wrongFlagCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(WrongFlagCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WrongFlagCount = reader.ReadByte();
        }
    }
}