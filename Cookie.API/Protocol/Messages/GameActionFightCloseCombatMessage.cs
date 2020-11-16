using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const ushort ProtocolId = 6116;

        public override ushort MessageID => ProtocolId;

        public ushort WeaponGenericId { get; set; }
        public GameActionFightCloseCombatMessage() { }

        public GameActionFightCloseCombatMessage( ushort WeaponGenericId ){
            this.WeaponGenericId = WeaponGenericId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(WeaponGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WeaponGenericId = reader.ReadVarUhShort();
        }
    }
}
