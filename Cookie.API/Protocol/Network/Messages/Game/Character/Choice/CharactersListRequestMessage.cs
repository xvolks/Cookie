using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 150;

        public override uint MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            //
        }

        public override void Deserialize(IDataReader reader)
        {
            //
        }
    }
}