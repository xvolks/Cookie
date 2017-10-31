namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class AbstractPartyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6274;
        public override ushort MessageID => ProtocolId;
        public uint PartyId { get; set; }

        public AbstractPartyMessage(uint partyId)
        {
            PartyId = partyId;
        }

        public AbstractPartyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(PartyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PartyId = reader.ReadVarUhInt();
        }

    }
}
