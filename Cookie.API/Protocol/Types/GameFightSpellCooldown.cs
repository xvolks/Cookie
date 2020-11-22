using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightSpellCooldown : NetworkType
    {
        public const ushort ProtocolId = 205;

        public override ushort TypeID => ProtocolId;

        public int SpellId { get; set; }
        public sbyte Cooldown { get; set; }
        public GameFightSpellCooldown() { }

        public GameFightSpellCooldown( int SpellId, sbyte Cooldown ){
            this.SpellId = SpellId;
            this.Cooldown = Cooldown;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellId);
            writer.WriteSByte(Cooldown);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadInt();
            Cooldown = reader.ReadSByte();
        }
    }
}
