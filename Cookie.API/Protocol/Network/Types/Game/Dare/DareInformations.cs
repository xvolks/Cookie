using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Dare
{
    public class DareInformations : NetworkType
    {
        public const ushort ProtocolId = 502;

        public DareInformations(double dareId, CharacterBasicMinimalInformations creator, ulong subscriptionFee,
            ulong jackpot, ushort maxCountWinners, double endDate, bool isPrivate, uint guildId, uint allianceId,
            List<DareCriteria> criterions, double startDate)
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

        public DareInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double DareId { get; set; }
        public CharacterBasicMinimalInformations Creator { get; set; }
        public ulong SubscriptionFee { get; set; }
        public ulong Jackpot { get; set; }
        public ushort MaxCountWinners { get; set; }
        public double EndDate { get; set; }
        public bool IsPrivate { get; set; }
        public uint GuildId { get; set; }
        public uint AllianceId { get; set; }
        public List<DareCriteria> Criterions { get; set; }
        public double StartDate { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            Creator.Serialize(writer);
            writer.WriteVarUhLong(SubscriptionFee);
            writer.WriteVarUhLong(Jackpot);
            writer.WriteUShort(MaxCountWinners);
            writer.WriteDouble(EndDate);
            writer.WriteBoolean(IsPrivate);
            writer.WriteVarUhInt(GuildId);
            writer.WriteVarUhInt(AllianceId);
            writer.WriteShort((short) Criterions.Count);
            for (var criterionsIndex = 0; criterionsIndex < Criterions.Count; criterionsIndex++)
            {
                var objectToSend = Criterions[criterionsIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteDouble(StartDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareId = reader.ReadDouble();
            Creator = new CharacterBasicMinimalInformations();
            Creator.Deserialize(reader);
            SubscriptionFee = reader.ReadVarUhLong();
            Jackpot = reader.ReadVarUhLong();
            MaxCountWinners = reader.ReadUShort();
            EndDate = reader.ReadDouble();
            IsPrivate = reader.ReadBoolean();
            GuildId = reader.ReadVarUhInt();
            AllianceId = reader.ReadVarUhInt();
            var criterionsCount = reader.ReadUShort();
            Criterions = new List<DareCriteria>();
            for (var criterionsIndex = 0; criterionsIndex < criterionsCount; criterionsIndex++)
            {
                var objectToAdd = new DareCriteria();
                objectToAdd.Deserialize(reader);
                Criterions.Add(objectToAdd);
            }
            StartDate = reader.ReadDouble();
        }
    }
}