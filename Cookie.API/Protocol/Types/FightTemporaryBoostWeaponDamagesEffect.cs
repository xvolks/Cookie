using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
    {
        public new const ushort ProtocolId = 211;

        public override ushort TypeID => ProtocolId;

        public short WeaponTypeId { get; set; }
        public FightTemporaryBoostWeaponDamagesEffect() { }

        public FightTemporaryBoostWeaponDamagesEffect( short WeaponTypeId ){
            this.WeaponTypeId = WeaponTypeId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WeaponTypeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WeaponTypeId = reader.ReadShort();
        }
    }
}
