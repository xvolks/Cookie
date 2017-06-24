using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 150;

        public override uint MessageID => ProtocolId;

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