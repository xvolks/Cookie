using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightEntityDispositionInformations : EntityDispositionInformations
    {
        public new const short ProtocolId = 217;
        public override short TypeId { get { return ProtocolId; } }

        public double CarryingCharacterId = 0;

        public FightEntityDispositionInformations(): base()
        {
        }

        public FightEntityDispositionInformations(
            short cellId,
            byte direction,
            double carryingCharacterId
        ): base(
            cellId,
            direction
        )
        {
            CarryingCharacterId = carryingCharacterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(CarryingCharacterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CarryingCharacterId = reader.ReadDouble();
        }
    }
}