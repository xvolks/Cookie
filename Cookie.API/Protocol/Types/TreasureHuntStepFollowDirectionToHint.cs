using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TreasureHuntStepFollowDirectionToHint : TreasureHuntStep
    {
        public new const ushort ProtocolId = 472;

        public override ushort TypeID => ProtocolId;

        public sbyte Direction { get; set; }
        public ushort NpcId { get; set; }
        public TreasureHuntStepFollowDirectionToHint() { }

        public TreasureHuntStepFollowDirectionToHint( sbyte Direction, ushort NpcId ){
            this.Direction = Direction;
            this.NpcId = NpcId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Direction);
            writer.WriteVarUhShort(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadSByte();
            NpcId = reader.ReadVarUhShort();
        }
    }
}
