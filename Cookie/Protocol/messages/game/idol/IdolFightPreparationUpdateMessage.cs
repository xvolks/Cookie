using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolFightPreparationUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6586;
        public override uint MessageID { get { return ProtocolId; } }

        public byte IdolSource = 0;
        public List<Idol> Idols;

        public IdolFightPreparationUpdateMessage()
        {
        }

        public IdolFightPreparationUpdateMessage(
            byte idolSource,
            List<Idol> idols
        )
        {
            IdolSource = idolSource;
            Idols = idols;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(IdolSource);
            writer.WriteShort((short)Idols.Count());
            foreach (var current in Idols)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            IdolSource = reader.ReadByte();
            var countIdols = reader.ReadShort();
            Idols = new List<Idol>();
            for (short i = 0; i < countIdols; i++)
            {
                var idolstypeId = reader.ReadShort();
                Idol type = new Idol();
                type.Deserialize(reader);
                Idols.Add(type);
            }
        }
    }
}