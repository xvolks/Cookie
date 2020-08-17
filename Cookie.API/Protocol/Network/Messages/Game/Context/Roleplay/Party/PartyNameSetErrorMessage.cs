using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyNameSetErrorMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6501;

        public PartyNameSetErrorMessage(byte result)
        {
            Result = result;
        }

        public PartyNameSetErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Result = reader.ReadByte();
        }
    }
}