using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightResultFighterListEntry : FightResultListEntry
    {
        public new const ushort ProtocolId = 189;

        public FightResultFighterListEntry(double objectId, bool alive)
        {
            ObjectId = objectId;
            Alive = alive;
        }

        public FightResultFighterListEntry()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double ObjectId { get; set; }
        public bool Alive { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(ObjectId);
            writer.WriteBoolean(Alive);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectId = reader.ReadDouble();
            Alive = reader.ReadBoolean();
        }
    }
}