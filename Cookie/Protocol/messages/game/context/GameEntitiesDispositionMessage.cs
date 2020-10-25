using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameEntitiesDispositionMessage : NetworkMessage
    {
        public const uint ProtocolId = 5696;
        public override uint MessageID { get { return ProtocolId; } }

        public List<IdentifiedEntityDispositionInformations> Dispositions;

        public GameEntitiesDispositionMessage()
        {
        }

        public GameEntitiesDispositionMessage(
            List<IdentifiedEntityDispositionInformations> dispositions
        )
        {
            Dispositions = dispositions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Dispositions.Count());
            foreach (var current in Dispositions)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countDispositions = reader.ReadShort();
            Dispositions = new List<IdentifiedEntityDispositionInformations>();
            for (short i = 0; i < countDispositions; i++)
            {
                IdentifiedEntityDispositionInformations type = new IdentifiedEntityDispositionInformations();
                type.Deserialize(reader);
                Dispositions.Add(type);
            }
        }
    }
}