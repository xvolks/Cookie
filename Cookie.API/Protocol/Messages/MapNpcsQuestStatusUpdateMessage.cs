using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapNpcsQuestStatusUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5642;

        public override ushort MessageID => ProtocolId;

        public double MapId { get; set; }
        public List<int> NpcsIdsWithQuest { get; set; }
        public List<GameRolePlayNpcQuestFlag> QuestFlags { get; set; }
        public List<int> NpcsIdsWithoutQuest { get; set; }
        public MapNpcsQuestStatusUpdateMessage() { }

        public MapNpcsQuestStatusUpdateMessage( double MapId, List<int> NpcsIdsWithQuest, List<GameRolePlayNpcQuestFlag> QuestFlags, List<int> NpcsIdsWithoutQuest ){
            this.MapId = MapId;
            this.NpcsIdsWithQuest = NpcsIdsWithQuest;
            this.QuestFlags = QuestFlags;
            this.NpcsIdsWithoutQuest = NpcsIdsWithoutQuest;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
			writer.WriteShort((short)NpcsIdsWithQuest.Count);
			foreach (var x in NpcsIdsWithQuest)
			{
				writer.WriteInt(x);
			}
			writer.WriteShort((short)QuestFlags.Count);
			foreach (var x in QuestFlags)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)NpcsIdsWithoutQuest.Count);
			foreach (var x in NpcsIdsWithoutQuest)
			{
				writer.WriteInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            var NpcsIdsWithQuestCount = reader.ReadShort();
            NpcsIdsWithQuest = new List<int>();
            for (var i = 0; i < NpcsIdsWithQuestCount; i++)
            {
                NpcsIdsWithQuest.Add(reader.ReadInt());
            }
            var QuestFlagsCount = reader.ReadShort();
            QuestFlags = new List<GameRolePlayNpcQuestFlag>();
            for (var i = 0; i < QuestFlagsCount; i++)
            {
                var objectToAdd = new GameRolePlayNpcQuestFlag();
                objectToAdd.Deserialize(reader);
                QuestFlags.Add(objectToAdd);
            }
            var NpcsIdsWithoutQuestCount = reader.ReadShort();
            NpcsIdsWithoutQuest = new List<int>();
            for (var i = 0; i < NpcsIdsWithoutQuestCount; i++)
            {
                NpcsIdsWithoutQuest.Add(reader.ReadInt());
            }
        }
    }
}
