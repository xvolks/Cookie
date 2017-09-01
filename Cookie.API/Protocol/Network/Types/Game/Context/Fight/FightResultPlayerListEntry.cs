using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightResultPlayerListEntry : FightResultFighterListEntry
    {
        public new const ushort ProtocolId = 24;

        public FightResultPlayerListEntry(byte level, List<FightResultAdditionalData> additional)
        {
            Level = level;
            Additional = additional;
        }

        public FightResultPlayerListEntry()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Level { get; set; }
        public List<FightResultAdditionalData> Additional { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Level);
            writer.WriteShort((short) Additional.Count);
            for (var additionalIndex = 0; additionalIndex < Additional.Count; additionalIndex++)
            {
                var objectToSend = Additional[additionalIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadByte();
            var additionalCount = reader.ReadUShort();
            Additional = new List<FightResultAdditionalData>();
            for (var additionalIndex = 0; additionalIndex < additionalCount; additionalIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<FightResultAdditionalData>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Additional.Add(objectToAdd);
            }
        }
    }
}