using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyInvitationMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5586;

        public override ushort MessageID => ProtocolId;

        public sbyte PartyType { get; set; }
        public string PartyName { get; set; }
        public sbyte MaxParticipants { get; set; }
        public ulong FromId { get; set; }
        public string FromName { get; set; }
        public ulong ToId { get; set; }
        public PartyInvitationMessage() { }

        public PartyInvitationMessage( sbyte PartyType, string PartyName, sbyte MaxParticipants, ulong FromId, string FromName, ulong ToId ){
            this.PartyType = PartyType;
            this.PartyName = PartyName;
            this.MaxParticipants = MaxParticipants;
            this.FromId = FromId;
            this.FromName = FromName;
            this.ToId = ToId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PartyType);
            writer.WriteUTF(PartyName);
            writer.WriteSByte(MaxParticipants);
            writer.WriteVarUhLong(FromId);
            writer.WriteUTF(FromName);
            writer.WriteVarUhLong(ToId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyType = reader.ReadSByte();
            PartyName = reader.ReadUTF();
            MaxParticipants = reader.ReadSByte();
            FromId = reader.ReadVarUhLong();
            FromName = reader.ReadUTF();
            ToId = reader.ReadVarUhLong();
        }
    }
}
