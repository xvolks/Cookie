using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NpcGenericActionRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5898;

        public override ushort MessageID => ProtocolId;

        public int NpcId { get; set; }
        public sbyte NpcActionId { get; set; }
        public double NpcMapId { get; set; }
        public NpcGenericActionRequestMessage() { }

        public NpcGenericActionRequestMessage( int NpcId, sbyte NpcActionId, double NpcMapId ){
            this.NpcId = NpcId;
            this.NpcActionId = NpcActionId;
            this.NpcMapId = NpcMapId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(NpcId);
            writer.WriteSByte(NpcActionId);
            writer.WriteDouble(NpcMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            NpcId = reader.ReadInt();
            NpcActionId = reader.ReadSByte();
            NpcMapId = reader.ReadDouble();
        }
    }
}
