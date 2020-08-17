using Cookie.API.Protocol.Network.Types.Game.Prism;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismFightAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6452;

        public PrismFightAddedMessage(PrismFightersInformation fight)
        {
            Fight = fight;
        }

        public PrismFightAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public PrismFightersInformation Fight { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Fight.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Fight = new PrismFightersInformation();
            Fight.Deserialize(reader);
        }
    }
}