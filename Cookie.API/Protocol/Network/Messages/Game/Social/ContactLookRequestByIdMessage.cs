using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    public class ContactLookRequestByIdMessage : ContactLookRequestMessage
    {
        public new const ushort ProtocolId = 5935;

        public ContactLookRequestByIdMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public ContactLookRequestByIdMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
        }
    }
}