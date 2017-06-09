using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 150;
        public override uint MessageID { get { return ProtocolId; } }

        public CharactersListRequestMessage() { }

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
