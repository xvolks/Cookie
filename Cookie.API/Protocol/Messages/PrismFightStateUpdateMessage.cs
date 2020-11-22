using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismFightStateUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6040;

        public override ushort MessageID => ProtocolId;

        public sbyte State { get; set; }
        public PrismFightStateUpdateMessage() { }

        public PrismFightStateUpdateMessage( sbyte State ){
            this.State = State;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            State = reader.ReadSByte();
        }
    }
}
