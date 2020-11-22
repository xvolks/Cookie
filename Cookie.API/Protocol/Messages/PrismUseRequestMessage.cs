using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismUseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6041;

        public override ushort MessageID => ProtocolId;

        public sbyte ModuleToUse { get; set; }
        public PrismUseRequestMessage() { }

        public PrismUseRequestMessage( sbyte ModuleToUse ){
            this.ModuleToUse = ModuleToUse;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ModuleToUse);
        }

        public override void Deserialize(IDataReader reader)
        {
            ModuleToUse = reader.ReadSByte();
        }
    }
}
