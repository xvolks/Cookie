using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PlayerStatus : NetworkType
    {
        public const ushort ProtocolId = 415;

        public override ushort TypeID => ProtocolId;

        public sbyte StatusId { get; set; }
        public PlayerStatus() { }

        public PlayerStatus( sbyte StatusId ){
            this.StatusId = StatusId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(StatusId);
        }

        public override void Deserialize(IDataReader reader)
        {
            StatusId = reader.ReadSByte();
        }
    }
}
