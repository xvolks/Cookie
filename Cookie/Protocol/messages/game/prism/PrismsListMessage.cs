using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6440;
        public override uint MessageID { get { return ProtocolId; } }

        public List<PrismSubareaEmptyInfo> Prisms;

        public PrismsListMessage()
        {
        }

        public PrismsListMessage(
            List<PrismSubareaEmptyInfo> prisms
        )
        {
            Prisms = prisms;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Prisms.Count());
            foreach (var current in Prisms)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countPrisms = reader.ReadShort();
            Prisms = new List<PrismSubareaEmptyInfo>();
            for (short i = 0; i < countPrisms; i++)
            {
                var prismstypeId = reader.ReadShort();
                PrismSubareaEmptyInfo type = new PrismSubareaEmptyInfo();
                type.Deserialize(reader);
                Prisms.Add(type);
            }
        }
    }
}