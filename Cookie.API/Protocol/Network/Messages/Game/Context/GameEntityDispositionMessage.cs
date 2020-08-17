using Cookie.API.Protocol.Network.Types.Game.Context;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameEntityDispositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5693;

        public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition)
        {
            Disposition = disposition;
        }

        public GameEntityDispositionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public IdentifiedEntityDispositionInformations Disposition { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Disposition.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Disposition = new IdentifiedEntityDispositionInformations();
            Disposition.Deserialize(reader);
        }
    }
}