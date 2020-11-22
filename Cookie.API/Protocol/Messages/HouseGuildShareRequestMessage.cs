using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HouseGuildShareRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5704;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool Enable { get; set; }
        public uint Rights { get; set; }
        public HouseGuildShareRequestMessage() { }

        public HouseGuildShareRequestMessage( uint HouseId, int InstanceId, bool Enable, uint Rights ){
            this.HouseId = HouseId;
            this.InstanceId = InstanceId;
            this.Enable = Enable;
            this.Rights = Rights;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(Enable);
            writer.WriteVarUhInt(Rights);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            Enable = reader.ReadBoolean();
            Rights = reader.ReadVarUhInt();
        }
    }
}
