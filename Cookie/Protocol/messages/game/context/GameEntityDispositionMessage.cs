using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameEntityDispositionMessage : NetworkMessage
    {
        public const uint ProtocolId = 5693;
        public override uint MessageID { get { return ProtocolId; } }

        public IdentifiedEntityDispositionInformations Disposition;

        public GameEntityDispositionMessage()
        {
        }

        public GameEntityDispositionMessage(
            IdentifiedEntityDispositionInformations disposition
        )
        {
            Disposition = disposition;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Disposition.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Disposition = new IdentifiedEntityDispositionInformations();
            Disposition.Deserialize(reader);
        }
    }
}