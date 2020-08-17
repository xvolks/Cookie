using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5585;

        public PartyInvitationRequestMessage(string name)
        {
            Name = name;
        }

        public PartyInvitationRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }
    }
}