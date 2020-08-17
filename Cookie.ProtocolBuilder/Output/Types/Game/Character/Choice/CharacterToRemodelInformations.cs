namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    using System.Collections.Generic;
    using Utils.IO;

    public class CharacterToRemodelInformations : CharacterRemodelingInformation
    {
        public new const ushort ProtocolId = 477;
        public override ushort TypeID => ProtocolId;
        public byte PossibleChangeMask { get; set; }
        public byte MandatoryChangeMask { get; set; }

        public CharacterToRemodelInformations(byte possibleChangeMask, byte mandatoryChangeMask)
        {
            PossibleChangeMask = possibleChangeMask;
            MandatoryChangeMask = mandatoryChangeMask;
        }

        public CharacterToRemodelInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PossibleChangeMask);
            writer.WriteByte(MandatoryChangeMask);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PossibleChangeMask = reader.ReadByte();
            MandatoryChangeMask = reader.ReadByte();
        }

    }
}
