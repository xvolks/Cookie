using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceCreationValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6393;
        public override uint MessageID { get { return ProtocolId; } }

        public string AllianceName;
        public string AllianceTag;
        public GuildEmblem AllianceEmblem;

        public AllianceCreationValidMessage()
        {
        }

        public AllianceCreationValidMessage(
            string allianceName,
            string allianceTag,
            GuildEmblem allianceEmblem
        )
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
            AllianceEmblem = allianceEmblem;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
            AllianceEmblem.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
            AllianceEmblem = new GuildEmblem();
            AllianceEmblem.Deserialize(reader);
        }
    }
}