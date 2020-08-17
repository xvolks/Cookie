using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharacterSelectedErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5836;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}