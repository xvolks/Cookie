using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildFightTakePlaceRequestMessage : GuildFightJoinRequestMessage
    {
        public new const ushort ProtocolId = 6235;

        public override ushort MessageID => ProtocolId;

        public int ReplacedCharacterId { get; set; }
        public GuildFightTakePlaceRequestMessage() { }

        public GuildFightTakePlaceRequestMessage( int ReplacedCharacterId ){
            this.ReplacedCharacterId = ReplacedCharacterId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(ReplacedCharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ReplacedCharacterId = reader.ReadInt();
        }
    }
}
