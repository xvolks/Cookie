using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class CharacterToRemodelInformations : CharacterRemodelingInformation
    {
        public new const ushort ProtocolId = 477;

        public override ushort TypeID => ProtocolId;

        public sbyte PossibleChangeMask { get; set; }
        public sbyte MandatoryChangeMask { get; set; }
        public CharacterToRemodelInformations() { }

        public CharacterToRemodelInformations( sbyte PossibleChangeMask, sbyte MandatoryChangeMask ){
            this.PossibleChangeMask = PossibleChangeMask;
            this.MandatoryChangeMask = MandatoryChangeMask;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PossibleChangeMask);
            writer.WriteSByte(MandatoryChangeMask);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PossibleChangeMask = reader.ReadSByte();
            MandatoryChangeMask = reader.ReadSByte();
        }
    }
}
