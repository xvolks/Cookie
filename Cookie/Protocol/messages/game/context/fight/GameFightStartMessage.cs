using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightStartMessage : NetworkMessage
    {
        public const uint ProtocolId = 712;
        public override uint MessageID { get { return ProtocolId; } }

        public List<Idol> Idols;

        public GameFightStartMessage()
        {
        }

        public GameFightStartMessage(
            List<Idol> idols
        )
        {
            Idols = idols;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Idols.Count());
            foreach (var current in Idols)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countIdols = reader.ReadShort();
            Idols = new List<Idol>();
            for (short i = 0; i < countIdols; i++)
            {
                Idol type = new Idol();
                type.Deserialize(reader);
                Idols.Add(type);
            }
        }
    }
}