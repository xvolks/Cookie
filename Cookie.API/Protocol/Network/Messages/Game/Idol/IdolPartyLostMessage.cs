using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    public class IdolPartyLostMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6580;

        public IdolPartyLostMessage(ushort idolId)
        {
            IdolId = idolId;
        }

        public IdolPartyLostMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort IdolId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            IdolId = reader.ReadVarUhShort();
        }
    }
}