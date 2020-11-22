using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SpellListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1200;

        public override ushort MessageID => ProtocolId;

        public bool SpellPrevisualization { get; set; }
        public List<SpellItem> Spells { get; set; }
        public SpellListMessage() { }

        public SpellListMessage( bool SpellPrevisualization, List<SpellItem> Spells ){
            this.SpellPrevisualization = SpellPrevisualization;
            this.Spells = Spells;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(SpellPrevisualization);
			writer.WriteShort((short)Spells.Count);
			foreach (var x in Spells)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellPrevisualization = reader.ReadBoolean();
            var SpellsCount = reader.ReadShort();
            Spells = new List<SpellItem>();
            for (var i = 0; i < SpellsCount; i++)
            {
                var objectToAdd = new SpellItem();
                objectToAdd.Deserialize(reader);
                Spells.Add(objectToAdd);
            }
        }
    }
}
