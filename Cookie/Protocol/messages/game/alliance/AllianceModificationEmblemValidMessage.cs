using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceModificationEmblemValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6447;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildEmblem Alliancemblem;

        public AllianceModificationEmblemValidMessage()
        {
        }

        public AllianceModificationEmblemValidMessage(
            GuildEmblem alliancemblem
        )
        {
            Alliancemblem = alliancemblem;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Alliancemblem.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Alliancemblem = new GuildEmblem();
            Alliancemblem.Deserialize(reader);
        }
    }
}