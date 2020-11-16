using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5554;

        public override ushort MessageID => ProtocolId;

        public sbyte Result { get; set; }
        public GuildCreationResultMessage() { }

        public GuildCreationResultMessage( sbyte Result ){
            this.Result = Result;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadSByte();
        }
    }
}
