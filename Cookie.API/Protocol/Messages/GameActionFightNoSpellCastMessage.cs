using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightNoSpellCastMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6132;

        public override ushort MessageID => ProtocolId;

        public uint SpellLevelId { get; set; }
        public GameActionFightNoSpellCastMessage() { }

        public GameActionFightNoSpellCastMessage( uint SpellLevelId ){
            this.SpellLevelId = SpellLevelId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SpellLevelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellLevelId = reader.ReadVarUhInt();
        }
    }
}
