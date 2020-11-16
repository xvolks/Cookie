using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayNpcQuestFlag : NetworkType
    {
        public const short ProtocolId = 384;
        public override short TypeId { get { return ProtocolId; } }

        public List<short> QuestsToValidId;
        public List<short> QuestsToStartId;

        public GameRolePlayNpcQuestFlag()
        {
        }

        public GameRolePlayNpcQuestFlag(
            List<short> questsToValidId,
            List<short> questsToStartId
        )
        {
            QuestsToValidId = questsToValidId;
            QuestsToStartId = questsToStartId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)QuestsToValidId.Count());
            foreach (var current in QuestsToValidId)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)QuestsToStartId.Count());
            foreach (var current in QuestsToStartId)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countQuestsToValidId = reader.ReadShort();
            QuestsToValidId = new List<short>();
            for (short i = 0; i < countQuestsToValidId; i++)
            {
                QuestsToValidId.Add(reader.ReadVarShort());
            }
            var countQuestsToStartId = reader.ReadShort();
            QuestsToStartId = new List<short>();
            for (short i = 0; i < countQuestsToStartId; i++)
            {
                QuestsToStartId.Add(reader.ReadVarShort());
            }
        }
    }
}