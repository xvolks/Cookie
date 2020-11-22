using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public new const ushort ProtocolId = 3;

        public override ushort TypeID => ProtocolId;

        public ushort MonsterId { get; set; }
        public sbyte PowerLevel { get; set; }
        public GameRolePlayMutantInformations() { }

        public GameRolePlayMutantInformations( ushort MonsterId, sbyte PowerLevel ){
            this.MonsterId = MonsterId;
            this.PowerLevel = PowerLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(MonsterId);
            writer.WriteSByte(PowerLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterId = reader.ReadVarUhShort();
            PowerLevel = reader.ReadSByte();
        }
    }
}
