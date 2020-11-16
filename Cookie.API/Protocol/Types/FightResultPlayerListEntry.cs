using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightResultPlayerListEntry : FightResultFighterListEntry
    {
        public new const ushort ProtocolId = 24;

        public override ushort TypeID => ProtocolId;

        public ushort Level { get; set; }
        public List<FightResultAdditionalData> Additional { get; set; }
        public FightResultPlayerListEntry() { }

        public FightResultPlayerListEntry( ushort Level, List<FightResultAdditionalData> Additional ){
            this.Level = Level;
            this.Additional = Additional;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Level);
			writer.WriteShort((short)Additional.Count);
			foreach (var x in Additional)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarUhShort();
            var AdditionalCount = reader.ReadShort();
            Additional = new List<FightResultAdditionalData>();
            for (var i = 0; i < AdditionalCount; i++)
            {
                FightResultAdditionalData objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Additional.Add(objectToAdd);
            }
        }
    }
}
