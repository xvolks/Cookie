using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildChangeMemberParametersMessage : NetworkMessage
    {
        public const uint ProtocolId = 5549;
        public override uint MessageID { get { return ProtocolId; } }

        public long MemberId = 0;
        public short Rank = 0;
        public byte ExperienceGivenPercent = 0;
        public int Rights = 0;

        public GuildChangeMemberParametersMessage()
        {
        }

        public GuildChangeMemberParametersMessage(
            long memberId,
            short rank,
            byte experienceGivenPercent,
            int rights
        )
        {
            MemberId = memberId;
            Rank = rank;
            ExperienceGivenPercent = experienceGivenPercent;
            Rights = rights;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(MemberId);
            writer.WriteVarShort(Rank);
            writer.WriteByte(ExperienceGivenPercent);
            writer.WriteVarInt(Rights);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MemberId = reader.ReadVarLong();
            Rank = reader.ReadVarShort();
            ExperienceGivenPercent = reader.ReadByte();
            Rights = reader.ReadVarInt();
        }
    }
}