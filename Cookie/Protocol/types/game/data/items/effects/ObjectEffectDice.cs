using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ObjectEffectDice : ObjectEffect
    {
        public new const short ProtocolId = 73;
        public override short TypeId { get { return ProtocolId; } }

        public int DiceNum = 0;
        public int DiceSide = 0;
        public int DiceConst = 0;

        public ObjectEffectDice(): base()
        {
        }

        public ObjectEffectDice(
            short actionId,
            int diceNum,
            int diceSide,
            int diceConst
        ): base(
            actionId
        )
        {
            DiceNum = diceNum;
            DiceSide = diceSide;
            DiceConst = diceConst;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(DiceNum);
            writer.WriteVarInt(DiceSide);
            writer.WriteVarInt(DiceConst);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            DiceNum = reader.ReadVarInt();
            DiceSide = reader.ReadVarInt();
            DiceConst = reader.ReadVarInt();
        }
    }
}