using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Atlas
{
    public class AtlasPointInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5956;

        public AtlasPointInformationsMessage(AtlasPointsInformations type)
        {
            Type = type;
        }

        public AtlasPointInformationsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public AtlasPointsInformations Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Type.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = new AtlasPointsInformations();
            Type.Deserialize(reader);
        }
    }
}