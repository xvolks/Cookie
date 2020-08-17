using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntStepFight : TreasureHuntStep
    {
        public new const ushort ProtocolId = 462;

        public override ushort TypeID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
    }
}