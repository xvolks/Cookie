using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildSpellUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5699;

        public override ushort MessageID => ProtocolId;

        public int SpellId { get; set; }
        public GuildSpellUpgradeRequestMessage() { }

        public GuildSpellUpgradeRequestMessage( int SpellId ){
            this.SpellId = SpellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadInt();
        }
    }
}
