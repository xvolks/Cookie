using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    public class ObjectEffectLadder : ObjectEffectCreature
    {
        public new const ushort ProtocolId = 81;

        public ObjectEffectLadder(uint monsterCount)
        {
            MonsterCount = monsterCount;
        }

        public ObjectEffectLadder()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint MonsterCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(MonsterCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MonsterCount = reader.ReadVarUhInt();
        }
    }
}