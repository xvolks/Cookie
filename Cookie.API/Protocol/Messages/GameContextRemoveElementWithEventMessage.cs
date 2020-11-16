using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextRemoveElementWithEventMessage : GameContextRemoveElementMessage
    {
        public new const ushort ProtocolId = 6412;

        public override ushort MessageID => ProtocolId;

        public sbyte ElementEventId { get; set; }
        public GameContextRemoveElementWithEventMessage() { }

        public GameContextRemoveElementWithEventMessage( sbyte ElementEventId ){
            this.ElementEventId = ElementEventId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(ElementEventId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ElementEventId = reader.ReadSByte();
        }
    }
}
