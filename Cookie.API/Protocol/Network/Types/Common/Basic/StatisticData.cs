using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Common.Basic
{
    public class StatisticData : NetworkType
    {
        public const ushort ProtocolId = 484;

        public override ushort TypeID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }
    }
}