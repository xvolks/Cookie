using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightOptionToggleMessage : NetworkMessage
    {
        public const ushort ProtocolId = 707;

        public override ushort MessageID => ProtocolId;

        public sbyte Option { get; set; }
        public GameFightOptionToggleMessage() { }

        public GameFightOptionToggleMessage( sbyte Option ){
            this.Option = Option;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Option);
        }

        public override void Deserialize(IDataReader reader)
        {
            Option = reader.ReadSByte();
        }
    }
}
