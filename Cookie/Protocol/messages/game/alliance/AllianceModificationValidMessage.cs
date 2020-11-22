using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceModificationValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6450;
        public override uint MessageID { get { return ProtocolId; } }

        public string AllianceName;
        public string AllianceTag;
        public GuildEmblem Alliancemblem;

        public AllianceModificationValidMessage()
        {
        }

        public AllianceModificationValidMessage(
            string allianceName,
            string allianceTag,
            GuildEmblem alliancemblem
        )
        {
            AllianceName = allianceName;
            AllianceTag = allianceTag;
            Alliancemblem = alliancemblem;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }
    }
}