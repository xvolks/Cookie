using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class CharacterToRemodelInformations : CharacterRemodelingInformation
    {
        public new const short ProtocolId = 477;
        public override short TypeId { get { return ProtocolId; } }

        public byte PossibleChangeMask = 0;
        public byte MandatoryChangeMask = 0;

        public CharacterToRemodelInformations(): base()
        {
        }

        public CharacterToRemodelInformations(
            long id_,
            string name,
            byte breed,
            bool sex,
            short cosmeticId,
            List<int> colors,
            byte possibleChangeMask,
            byte mandatoryChangeMask
        ): base(
            id_,
            name,
            breed,
            sex,
            cosmeticId,
            colors
        )
        {
            PossibleChangeMask = possibleChangeMask;
            MandatoryChangeMask = mandatoryChangeMask;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PossibleChangeMask);
            writer.WriteByte(MandatoryChangeMask);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PossibleChangeMask = reader.ReadByte();
            MandatoryChangeMask = reader.ReadByte();
        }
    }
}