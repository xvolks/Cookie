using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
    {
        public new const short ProtocolId = 457;
        public override short TypeId { get { return ProtocolId; } }

        public short FirstNameId = 0;
        public short LastNameId = 0;

        public GameFightFighterTaxCollectorLightInformations(): base()
        {
        }

        public GameFightFighterTaxCollectorLightInformations(
            bool sex,
            bool alive,
            double id_,
            byte wave,
            short level,
            byte breed,
            short firstNameId,
            short lastNameId
        ): base(
            sex,
            alive,
            id_,
            wave,
            level,
            breed
        )
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(FirstNameId);
            writer.WriteVarShort(LastNameId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarShort();
            LastNameId = reader.ReadVarShort();
        }
    }
}