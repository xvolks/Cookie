using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AbstractPartyMemberInFightMessage : AbstractPartyMessage
    {
        public new const uint ProtocolId = 6825;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Reason = 0;
        public long MemberId = 0;
        public int MemberAccountId = 0;
        public string MemberName;
        public short FightId = 0;
        public short TimeBeforeFightStart = 0;

        public AbstractPartyMemberInFightMessage(): base()
        {
        }

        public AbstractPartyMemberInFightMessage(
            int partyId,
            byte reason,
            long memberId,
            int memberAccountId,
            string memberName,
            short fightId,
            short timeBeforeFightStart
        ): base(
            partyId
        )
        {
            Reason = reason;
            MemberId = memberId;
            MemberAccountId = memberAccountId;
            MemberName = memberName;
            FightId = fightId;
            TimeBeforeFightStart = timeBeforeFightStart;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Reason);
            writer.WriteVarLong(MemberId);
            writer.WriteInt(MemberAccountId);
            writer.WriteUTF(MemberName);
            writer.WriteVarShort(FightId);
            writer.WriteVarShort(TimeBeforeFightStart);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadByte();
            MemberId = reader.ReadVarLong();
            MemberAccountId = reader.ReadInt();
            MemberName = reader.ReadUTF();
            FightId = reader.ReadVarShort();
            TimeBeforeFightStart = reader.ReadVarShort();
        }
    }
}