using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    public class ContactLookErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6045;

        public ContactLookErrorMessage(uint requestId)
        {
            RequestId = requestId;
        }

        public ContactLookErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint RequestId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(RequestId);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadVarUhInt();
        }
    }
}