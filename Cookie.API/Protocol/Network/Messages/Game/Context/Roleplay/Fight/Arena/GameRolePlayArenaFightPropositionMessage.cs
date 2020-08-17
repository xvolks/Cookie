using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6276;

        public GameRolePlayArenaFightPropositionMessage(int fightId, List<double> alliesId, ushort duration)
        {
            FightId = fightId;
            AlliesId = alliesId;
            Duration = duration;
        }

        public GameRolePlayArenaFightPropositionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public List<double> AlliesId { get; set; }
        public ushort Duration { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteShort((short) AlliesId.Count);
            for (var alliesIdIndex = 0; alliesIdIndex < AlliesId.Count; alliesIdIndex++)
                writer.WriteDouble(AlliesId[alliesIdIndex]);
            writer.WriteVarUhShort(Duration);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            var alliesIdCount = reader.ReadUShort();
            AlliesId = new List<double>();
            for (var alliesIdIndex = 0; alliesIdIndex < alliesIdCount; alliesIdIndex++)
                AlliesId.Add(reader.ReadDouble());
            Duration = reader.ReadVarUhShort();
        }
    }
}