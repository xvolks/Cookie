using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AbstractPartyMemberInFightMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6825;

        public override ushort MessageID => ProtocolId;

        public sbyte Reason { get; set; }
        public ulong MemberId { get; set; }
        public int MemberAccountId { get; set; }
        public string MemberName { get; set; }
        public ushort FightId { get; set; }
        public short TimeBeforeFightStart { get; set; }
        public AbstractPartyMemberInFightMessage() { }

        public AbstractPartyMemberInFightMessage( sbyte Reason, ulong MemberId, int MemberAccountId, string MemberName, ushort FightId, short TimeBeforeFightStart ){
            this.Reason = Reason;
            this.MemberId = MemberId;
            this.MemberAccountId = MemberAccountId;
            this.MemberName = MemberName;
            this.FightId = FightId;
            this.TimeBeforeFightStart = TimeBeforeFightStart;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Reason);
            writer.WriteVarUhLong(MemberId);
            writer.WriteInt(MemberAccountId);
            writer.WriteUTF(MemberName);
            writer.WriteVarUhShort(FightId);
            writer.WriteVarShort(TimeBeforeFightStart);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadSByte();
            MemberId = reader.ReadVarUhLong();
            MemberAccountId = reader.ReadInt();
            MemberName = reader.ReadUTF();
            FightId = reader.ReadVarUhShort();
            TimeBeforeFightStart = reader.ReadVarShort();
        }
    }
}
