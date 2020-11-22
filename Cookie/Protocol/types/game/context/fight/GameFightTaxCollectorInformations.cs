using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public new const short ProtocolId = 48;
        public override short TypeId { get { return ProtocolId; } }

        public short FirstNameId = 0;
        public short LastNameId = 0;
        public byte Level = 0;

        public GameFightTaxCollectorInformations(): base()
        {
        }

        public GameFightTaxCollectorInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            byte teamId,
            byte wave,
            bool alive,
            GameFightMinimalStats stats,
            List<short> previousPositions,
            short firstNameId,
            short lastNameId,
            byte level
        ): base(
            contextualId,
            look,
            disposition,
            teamId,
            wave,
            alive,
            stats,
            previousPositions
        )
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(FirstNameId);
            writer.WriteVarShort(LastNameId);
            writer.WriteByte(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarShort();
            LastNameId = reader.ReadVarShort();
            Level = reader.ReadByte();
        }
    }
}