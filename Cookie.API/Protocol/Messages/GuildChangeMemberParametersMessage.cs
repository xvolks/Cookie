using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildChangeMemberParametersMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5549;

        public override ushort MessageID => ProtocolId;

        public ulong MemberId { get; set; }
        public ushort Rank { get; set; }
        public sbyte ExperienceGivenPercent { get; set; }
        public uint Rights { get; set; }
        public GuildChangeMemberParametersMessage() { }

        public GuildChangeMemberParametersMessage( ulong MemberId, ushort Rank, sbyte ExperienceGivenPercent, uint Rights ){
            this.MemberId = MemberId;
            this.Rank = Rank;
            this.ExperienceGivenPercent = ExperienceGivenPercent;
            this.Rights = Rights;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(MemberId);
            writer.WriteVarUhShort(Rank);
            writer.WriteSByte(ExperienceGivenPercent);
            writer.WriteVarUhInt(Rights);
        }

        public override void Deserialize(IDataReader reader)
        {
            MemberId = reader.ReadVarUhLong();
            Rank = reader.ReadVarUhShort();
            ExperienceGivenPercent = reader.ReadSByte();
            Rights = reader.ReadVarUhInt();
        }
    }
}
