using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AchievementStartedObjective : AchievementObjective
    {
        public new const short ProtocolId = 402;
        public override short TypeId { get { return ProtocolId; } }

        public short Value = 0;

        public AchievementStartedObjective(): base()
        {
        }

        public AchievementStartedObjective(
            int id_,
            short maxValue,
            short value
        ): base(
            id_,
            maxValue
        )
        {
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Value = reader.ReadVarShort();
        }
    }
}