using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BreachCharactersMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6811;

        public override ushort MessageID => ProtocolId;

        public List<long> Characters { get; set; }
        public BreachCharactersMessage() { }

        public BreachCharactersMessage( List<long> Characters ){
            this.Characters = Characters;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Characters.Count);
			foreach (var x in Characters)
			{
				writer.WriteVarLong(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var CharactersCount = reader.ReadShort();
            Characters = new List<long>();
            for (var i = 0; i < CharactersCount; i++)
            {
                Characters.Add(reader.ReadVarLong());
            }
        }
    }
}
