using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionEmote : HumanOption
    {
        public new const short ProtocolId = 407;
        public override short TypeId { get { return ProtocolId; } }

        public byte EmoteId = 0;
        public double EmoteStartTime = 0;

        public HumanOptionEmote(): base()
        {
        }

        public HumanOptionEmote(
            byte emoteId,
            double emoteStartTime
        ): base()
        {
            EmoteId = emoteId;
            EmoteStartTime = emoteStartTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(EmoteId);
            writer.WriteDouble(EmoteStartTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            EmoteId = reader.ReadByte();
            EmoteStartTime = reader.ReadDouble();
        }
    }
}