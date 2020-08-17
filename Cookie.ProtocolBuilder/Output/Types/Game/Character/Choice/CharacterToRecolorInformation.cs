namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    using System.Collections.Generic;
    using Utils.IO;

    public class CharacterToRecolorInformation : AbstractCharacterToRefurbishInformation
    {
        public new const ushort ProtocolId = 212;
        public override ushort TypeID => ProtocolId;

        public CharacterToRecolorInformation() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
