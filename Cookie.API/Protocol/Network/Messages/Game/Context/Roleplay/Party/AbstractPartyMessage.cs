using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class AbstractPartyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6274;

        public AbstractPartyMessage(uint partyId)
        {
            PartyId = partyId;
        }

        public AbstractPartyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint PartyId { get; set; }

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