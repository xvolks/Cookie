using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceKickRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6400;

        public AllianceKickRequestMessage(uint kickedId)
        {
            KickedId = kickedId;
        }

        public AllianceKickRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint KickedId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(KickedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            KickedId = reader.ReadVarUhInt();
        }
    }
}