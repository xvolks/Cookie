using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class DareInformations : NetworkType
    {
        public const ushort ProtocolId = 502;

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
        public DareInformations() { }

        public DareInformations( double DareId, CharacterBasicMinimalInformations Creator, ulong SubscriptionFee, ulong Jackpot, ushort MaxCountWinners, double EndDate, bool IsPrivate, uint GuildId, uint AllianceId, List<DareCriteria> Criterions, double StartDate ){
            this.DareId = DareId;
            this.Creator = Creator;
            this.SubscriptionFee = SubscriptionFee;
            this.Jackpot = Jackpot;
            this.MaxCountWinners = MaxCountWinners;
            this.EndDate = EndDate;
            this.IsPrivate = IsPrivate;
            this.GuildId = GuildId;
            this.AllianceId = AllianceId;
            this.Criterions = Criterions;
            this.StartDate = StartDate;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DareId);
            Creator.Serialize(writer);
            writer.WriteVarUhLong(SubscriptionFee);
            writer.WriteVarUhLong(Jackpot);
            writer.WriteUnsignedShort(MaxCountWinners);
            writer.WriteDouble(EndDate);
            writer.WriteBoolean(IsPrivate);
            writer.WriteVarUhInt(GuildId);
            writer.WriteVarUhInt(AllianceId);
			writer.WriteShort((short)Criterions.Count);
			foreach (var x in Criterions)
			{
				x.Serialize(writer);
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
            MaxCountWinners = reader.ReadUnsignedShort();
            EndDate = reader.ReadDouble();
            IsPrivate = reader.ReadBoolean();
            GuildId = reader.ReadVarUhInt();
            AllianceId = reader.ReadVarUhInt();
            var CriterionsCount = reader.ReadShort();
            Criterions = new List<DareCriteria>();
            for (var i = 0; i < CriterionsCount; i++)
            {
                var objectToAdd = new DareCriteria();
                objectToAdd.Deserialize(reader);
                Criterions.Add(objectToAdd);
            }
            StartDate = reader.ReadDouble();
        }
    }
}
