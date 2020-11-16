using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextCreateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 200;

        public override ushort MessageID => ProtocolId;

        public sbyte Context { get; set; }
        public GameContextCreateMessage() { }

        public GameContextCreateMessage( sbyte Context ){
            this.Context = Context;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Context);
        }

        public override void Deserialize(IDataReader reader)
        {
            Context = reader.ReadSByte();
        }
    }
}
