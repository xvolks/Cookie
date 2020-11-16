using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightMinimalStatsPreparation : GameFightMinimalStats
    {
        public new const ushort ProtocolId = 360;

        public override ushort TypeID => ProtocolId;

        public uint Initiative { get; set; }
        public GameFightMinimalStatsPreparation() { }

        public GameFightMinimalStatsPreparation( uint Initiative ){
            this.Initiative = Initiative;
        }

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
