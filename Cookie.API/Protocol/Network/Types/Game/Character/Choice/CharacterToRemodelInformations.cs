using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    public class CharacterToRemodelInformations : CharacterRemodelingInformation
    {
        public new const ushort ProtocolId = 477;

        public CharacterToRemodelInformations(byte possibleChangeMask, byte mandatoryChangeMask)
        {
            PossibleChangeMask = possibleChangeMask;
            MandatoryChangeMask = mandatoryChangeMask;
        }

        public CharacterToRemodelInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte PossibleChangeMask { get; set; }
        public byte MandatoryChangeMask { get; set; }

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