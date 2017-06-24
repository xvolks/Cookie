namespace Cookie.Protocol.Network.Messages.Game.Character.Creation
{
    using Cookie.IO;


    public class CharacterCanBeCreatedRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6732;
        public override uint MessageID => ProtocolId;

        public CharacterCanBeCreatedRequestMessage()
        {}

        public override void Serialize(ICustomDataOutput writer)
        {
            //
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            //
        }
    }
}