using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismSettingsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6437;

        public override ushort MessageID => ProtocolId;

        public ushort SubAreaId { get; set; }
        public sbyte StartDefenseTime { get; set; }
        public PrismSettingsRequestMessage() { }

        public PrismSettingsRequestMessage( ushort SubAreaId, sbyte StartDefenseTime ){
            this.SubAreaId = SubAreaId;
            this.StartDefenseTime = StartDefenseTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteSByte(StartDefenseTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            StartDefenseTime = reader.ReadSByte();
        }
    }
}
