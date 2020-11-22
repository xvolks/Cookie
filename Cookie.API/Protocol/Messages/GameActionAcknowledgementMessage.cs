using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionAcknowledgementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 957;

        public override ushort MessageID => ProtocolId;

        public bool Valid { get; set; }
        public sbyte ActionId { get; set; }
        public GameActionAcknowledgementMessage() { }

        public GameActionAcknowledgementMessage( bool Valid, sbyte ActionId ){
            this.Valid = Valid;
            this.ActionId = ActionId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Valid);
            writer.WriteSByte(ActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Valid = reader.ReadBoolean();
            ActionId = reader.ReadSByte();
        }
    }
}
