using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AcquaintanceInformation : AbstractContactInformations
    {
        public new const ushort ProtocolId = 561;

        public override ushort TypeID => ProtocolId;

        public sbyte PlayerState { get; set; }
        public AcquaintanceInformation() { }

        public AcquaintanceInformation( sbyte PlayerState ){
            this.PlayerState = PlayerState;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PlayerState);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerState = reader.ReadSByte();
        }
    }
}
