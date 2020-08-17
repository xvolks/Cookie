using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Actions.Fight
{
    public class FightTriggeredEffect : AbstractFightDispellableEffect
    {
        public new const ushort ProtocolId = 210;

        public FightTriggeredEffect(int param1, int param2, int param3, short delay)
        {
            Param1 = param1;
            Param2 = param2;
            Param3 = param3;
            Delay = delay;
        }

        public FightTriggeredEffect()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int Param1 { get; set; }
        public int Param2 { get; set; }
        public int Param3 { get; set; }
        public short Delay { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Param1);
            writer.WriteInt(Param2);
            writer.WriteInt(Param3);
            writer.WriteShort(Delay);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Param1 = reader.ReadInt();
            Param2 = reader.ReadInt();
            Param3 = reader.ReadInt();
            Delay = reader.ReadShort();
        }
    }
}