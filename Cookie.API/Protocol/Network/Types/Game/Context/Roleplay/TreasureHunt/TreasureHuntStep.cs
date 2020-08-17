using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntStep : NetworkType
    {
        public const ushort ProtocolId = 463;

        public override ushort TypeID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}