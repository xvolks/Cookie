using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Dare;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6661;

        public DareListMessage(List<DareInformations> dares)
        {
            Dares = dares;
        }

        public DareListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<DareInformations> Dares { get; set; }

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
            Dares = new List<DareInformations>();
            for (var daresIndex = 0; daresIndex < daresCount; daresIndex++)
            {
                var objectToAdd = new DareInformations();
                objectToAdd.Deserialize(reader);
                Dares.Add(objectToAdd);
            }
        }
    }
}