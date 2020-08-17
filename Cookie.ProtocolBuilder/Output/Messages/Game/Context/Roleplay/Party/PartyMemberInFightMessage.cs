namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Types.Game.Context;
    using Utils.IO;

    public class PartyMemberInFightMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6342;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }
        public ulong MemberId { get; set; }
        public int MemberAccountId { get; set; }
        public string MemberName { get; set; }
        public int FightId { get; set; }
        public MapCoordinatesExtended FightMap { get; set; }
        public short TimeBeforeFightStart { get; set; }

        public PartyMemberInFightMessage(byte reason, ulong memberId, int memberAccountId, string memberName, int fightId, MapCoordinatesExtended fightMap, short timeBeforeFightStart)
        {
            Reason = reason;
            MemberId = memberId;
            MemberAccountId = memberAccountId;
            MemberName = memberName;
            FightId = fightId;
            FightMap = fightMap;
            TimeBeforeFightStart = timeBeforeFightStart;
        }

        public PartyMemberInFightMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Reason);
            writer.WriteVarUhLong(MemberId);
            writer.WriteInt(MemberAccountId);
            writer.WriteUTF(MemberName);
            writer.WriteInt(FightId);
            FightMap.Serialize(writer);
            writer.WriteVarShort(TimeBeforeFightStart);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadByte();
            MemberId = reader.ReadVarUhLong();
            MemberAccountId = reader.ReadInt();
            MemberName = reader.ReadUTF();
            FightId = reader.ReadInt();
            FightMap = new MapCoordinatesExtended();
            FightMap.Deserialize(reader);
            TimeBeforeFightStart = reader.ReadVarShort();
        }

    }
}
