using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CinematicMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6053;

        public override ushort MessageID => ProtocolId;

        public ushort CinematicId { get; set; }
        public CinematicMessage() { }

        public CinematicMessage( ushort CinematicId ){
            this.CinematicId = CinematicId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CinematicId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CinematicId = reader.ReadVarUhShort();
        }
    }
}
