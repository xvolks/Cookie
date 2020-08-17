using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Quest
{
    public class GameRolePlayNpcQuestFlag : NetworkType
    {
        public const ushort ProtocolId = 384;

        public GameRolePlayNpcQuestFlag(List<ushort> questsToValidId, List<ushort> questsToStartId)
        {
            QuestsToValidId = questsToValidId;
            QuestsToStartId = questsToStartId;
        }

        public GameRolePlayNpcQuestFlag()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<ushort> QuestsToValidId { get; set; }
        public List<ushort> QuestsToStartId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) QuestsToValidId.Count);
            for (var questsToValidIdIndex = 0; questsToValidIdIndex < QuestsToValidId.Count; questsToValidIdIndex++)
                writer.WriteVarUhShort(QuestsToValidId[questsToValidIdIndex]);
            writer.WriteShort((short) QuestsToStartId.Count);
            for (var questsToStartIdIndex = 0; questsToStartIdIndex < QuestsToStartId.Count; questsToStartIdIndex++)
                writer.WriteVarUhShort(QuestsToStartId[questsToStartIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var questsToValidIdCount = reader.ReadUShort();
            QuestsToValidId = new List<ushort>();
            for (var questsToValidIdIndex = 0; questsToValidIdIndex < questsToValidIdCount; questsToValidIdIndex++)
                QuestsToValidId.Add(reader.ReadVarUhShort());
            var questsToStartIdCount = reader.ReadUShort();
            QuestsToStartId = new List<ushort>();
            for (var questsToStartIdIndex = 0; questsToStartIdIndex < questsToStartIdCount; questsToStartIdIndex++)
                QuestsToStartId.Add(reader.ReadVarUhShort());
        }
    }
}