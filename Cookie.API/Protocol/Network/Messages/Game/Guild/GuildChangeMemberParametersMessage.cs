using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildChangeMemberParametersMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5549;

        public GuildChangeMemberParametersMessage(ulong memberId, ushort rank, byte experienceGivenPercent, uint rights)
        {
            MemberId = memberId;
            Rank = rank;
            ExperienceGivenPercent = experienceGivenPercent;
            Rights = rights;
        }

        public GuildChangeMemberParametersMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong MemberId { get; set; }
        public ushort Rank { get; set; }
        public byte ExperienceGivenPercent { get; set; }
        public uint Rights { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(MemberId);
            writer.WriteVarUhShort(Rank);
            writer.WriteByte(ExperienceGivenPercent);
            writer.WriteVarUhInt(Rights);
        }

        public override void Deserialize(IDataReader reader)
        {
            MemberId = reader.ReadVarUhLong();
            Rank = reader.ReadVarUhShort();
            ExperienceGivenPercent = reader.ReadByte();
            Rights = reader.ReadVarUhInt();
        }
    }
}