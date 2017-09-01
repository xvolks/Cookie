using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyNameSetRequestMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6503;

        public PartyNameSetRequestMessage(string partyName)
        {
            PartyName = partyName;
        }

        public PartyNameSetRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string PartyName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PartyName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PartyName = reader.ReadUTF();
        }
    }
}