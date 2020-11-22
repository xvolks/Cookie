using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
    {
        public new const uint ProtocolId = 6235;
        public override uint MessageID { get { return ProtocolId; } }

        public int ReplacedCharacterId = 0;

        public GuildFightTakePlaceRequestMessage(): base()
        {
        }

        public GuildFightTakePlaceRequestMessage(
            double taxCollectorId,
            int replacedCharacterId
        ): base(
            taxCollectorId
        )
        {
            ReplacedCharacterId = replacedCharacterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ReplacedCharacterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ReplacedCharacterId = reader.ReadInt();
        }
    }
}