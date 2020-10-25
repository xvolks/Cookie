using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class DareInformations : NetworkType
    {
        public const short ProtocolId = 502;
        public override short TypeId { get { return ProtocolId; } }

        public double DareId = 0;
        public CharacterBasicMinimalInformations Creator;
        public long SubscriptionFee = 0;
        public long Jackpot = 0;
        public short MaxCountWinners = 0;
        public double EndDate = 0;
        public bool IsPrivate = false;
        public int GuildId = 0;
        public int AllianceId = 0;
        public List<DareCriteria> Criterions;
        public double StartDate = 0;

        public DareInformations()
        {
        }

        public DareInformations(
            double dareId,
            CharacterBasicMinimalInformations creator,
            long subscriptionFee,
            long jackpot,
            short maxCountWinners,
            double endDate,
            bool isPrivate,
            int guildId,
            int allianceId,
            List<DareCriteria> criterions,
            double startDate
        )
        {
            DareId = dareId;
            Creator = creator;
            SubscriptionFee = subscriptionFee;
            Jackpot = jackpot;
            MaxCountWinners = maxCountWinners;
            EndDate = endDate;
            IsPrivate = isPrivate;
            GuildId = guildId;
            AllianceId = allianceId;
            Criterions = criterions;
            StartDate = startDate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(DareId);
            Creator.Serialize(writer);
            writer.WriteVarLong(SubscriptionFee);
            writer.WriteVarLong(Jackpot);
            writer.WriteShort(MaxCountWinners);
            writer.WriteDouble(EndDate);
            writer.WriteBoolean(IsPrivate);
            writer.WriteVarInt(GuildId);
            writer.WriteVarInt(AllianceId);
            writer.WriteShort((short)Criterions.Count());
            foreach (var current in Criterions)
            {
                current.Serialize(writer);
            }
            writer.WriteDouble(StartDate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DareId = reader.ReadDouble();
            Creator = new CharacterBasicMinimalInformations();
            Creator.Deserialize(reader);
            SubscriptionFee = reader.ReadVarLong();
            Jackpot = reader.ReadVarLong();
            MaxCountWinners = reader.ReadShort();
            EndDate = reader.ReadDouble();
            IsPrivate = reader.ReadBoolean();
            GuildId = reader.ReadVarInt();
            AllianceId = reader.ReadVarInt();
            var countCriterions = reader.ReadShort();
            Criterions = new List<DareCriteria>();
            for (short i = 0; i < countCriterions; i++)
            {
                DareCriteria type = new DareCriteria();
                type.Deserialize(reader);
                Criterions.Add(type);
            }
            StartDate = reader.ReadDouble();
        }
    }
}