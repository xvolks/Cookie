using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class CloseHavenBagFurnitureSequenceRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6621;

        public override ushort MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}