using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Status
{
    public class PlayerStatusUpdateErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6385;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}