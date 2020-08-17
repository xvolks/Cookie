using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Dare;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareVersatileListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6657;

        public DareVersatileListMessage(List<DareVersatileInformations> dares)
        {
            Dares = dares;
        }

        public DareVersatileListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<DareVersatileInformations> Dares { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Dares.Count);
            for (var daresIndex = 0; daresIndex < Dares.Count; daresIndex++)
            {
                var objectToSend = Dares[daresIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var daresCount = reader.ReadUShort();
            Dares = new List<DareVersatileInformations>();
            for (var daresIndex = 0; daresIndex < daresCount; daresIndex++)
            {
                var objectToAdd = new DareVersatileInformations();
                objectToAdd.Deserialize(reader);
                Dares.Add(objectToAdd);
            }
        }
    }
}