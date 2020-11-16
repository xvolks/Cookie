using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextRemoveElementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 251;

        public override ushort MessageID => ProtocolId;

        public double Id { get; set; }
        public GameContextRemoveElementMessage() { }

        public GameContextRemoveElementMessage( double Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadDouble();
        }
    }
}
