using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
    {
        public new const ushort ProtocolId = 5668;

        public override ushort MessageID => ProtocolId;

        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }
        public LockableStateUpdateHouseDoorMessage() { }

        public LockableStateUpdateHouseDoorMessage( uint HouseId, int InstanceId, bool SecondHand ){
            this.HouseId = HouseId;
            this.InstanceId = InstanceId;
            this.SecondHand = SecondHand;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
        }
    }
}
