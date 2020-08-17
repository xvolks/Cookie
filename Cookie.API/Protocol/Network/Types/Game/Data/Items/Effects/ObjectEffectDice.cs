using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    public class ObjectEffectDice : ObjectEffect
    {
        public new const ushort ProtocolId = 73;

        public ObjectEffectDice(ushort diceNum, ushort diceSide, ushort diceConst)
        {
            DiceNum = diceNum;
            DiceSide = diceSide;
            DiceConst = diceConst;
        }

        public ObjectEffectDice()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort DiceNum { get; set; }
        public ushort DiceSide { get; set; }
        public ushort DiceConst { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(DiceNum);
            writer.WriteVarUhShort(DiceSide);
            writer.WriteVarUhShort(DiceConst);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DiceNum = reader.ReadVarUhShort();
            DiceSide = reader.ReadVarUhShort();
            DiceConst = reader.ReadVarUhShort();
        }
    }
}