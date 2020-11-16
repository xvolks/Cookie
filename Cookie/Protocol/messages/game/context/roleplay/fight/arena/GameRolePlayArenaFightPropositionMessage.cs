using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6276;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public List<double> AlliesId;
        public short Duration = 0;

        public GameRolePlayArenaFightPropositionMessage()
        {
        }

        public GameRolePlayArenaFightPropositionMessage(
            short fightId,
            List<double> alliesId,
            short duration
        )
        {
            FightId = fightId;
            AlliesId = alliesId;
            Duration = duration;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteShort((short)AlliesId.Count());
            foreach (var current in AlliesId)
            {
                writer.WriteDouble(current);
            }
            writer.WriteVarShort(Duration);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            var countAlliesId = reader.ReadShort();
            AlliesId = new List<double>();
            for (short i = 0; i < countAlliesId; i++)
            {
                AlliesId.Add(reader.ReadDouble());
            }
            Duration = reader.ReadVarShort();
        }
    }
}