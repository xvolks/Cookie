using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BreachCharactersMessage : NetworkMessage
    {
        public const uint ProtocolId = 6811;
        public override uint MessageID { get { return ProtocolId; } }

        public List<long> Characters;

        public BreachCharactersMessage()
        {
        }

        public BreachCharactersMessage(
            List<long> characters
        )
        {
            Characters = characters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Characters.Count());
            foreach (var current in Characters)
            {
                writer.WriteVarLong(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countCharacters = reader.ReadShort();
            Characters = new List<long>();
            for (short i = 0; i < countCharacters; i++)
            {
                Characters.Add(reader.ReadVarLong());
            }
        }
    }
}