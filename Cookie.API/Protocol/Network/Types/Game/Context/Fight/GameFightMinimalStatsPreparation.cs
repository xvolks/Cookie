using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightMinimalStatsPreparation : GameFightMinimalStats
    {
        public new const ushort ProtocolId = 360;

        public GameFightMinimalStatsPreparation(uint initiative)
        {
            Initiative = initiative;
        }

        public GameFightMinimalStatsPreparation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint Initiative { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Initiative);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Initiative = reader.ReadVarUhInt();
        }
    }
}