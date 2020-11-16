using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffectDice : ObjectEffect
    {
        public new const ushort ProtocolId = 73;

        public override ushort TypeID => ProtocolId;

        public uint DiceNum { get; set; }
        public uint DiceSide { get; set; }
        public uint DiceConst { get; set; }
        public ObjectEffectDice() { }

        public ObjectEffectDice( uint DiceNum, uint DiceSide, uint DiceConst ){
            this.DiceNum = DiceNum;
            this.DiceSide = DiceSide;
            this.DiceConst = DiceConst;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(DiceNum);
            writer.WriteVarUhInt(DiceSide);
            writer.WriteVarUhInt(DiceConst);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DiceNum = reader.ReadVarUhInt();
            DiceSide = reader.ReadVarUhInt();
            DiceConst = reader.ReadVarUhInt();
        }
    }
}
