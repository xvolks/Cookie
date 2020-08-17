using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyCannotJoinErrorMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 5583;

        public PartyCannotJoinErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public PartyCannotJoinErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Reason = reader.ReadByte();
        }
    }
}