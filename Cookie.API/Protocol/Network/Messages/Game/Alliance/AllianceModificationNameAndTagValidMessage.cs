using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceModificationNameAndTagValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6449;

        public AllianceModificationNameAndTagValidMessage(string allianceName, string allianceTag)
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
        }

        public AllianceModificationNameAndTagValidMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
        }
    }
}