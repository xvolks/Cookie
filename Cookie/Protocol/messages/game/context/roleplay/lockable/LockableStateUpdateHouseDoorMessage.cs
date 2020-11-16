using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
    {
        public new const uint ProtocolId = 5668;
        public override uint MessageID { get { return ProtocolId; } }

        public int HouseId = 0;
        public int InstanceId = 0;
        public bool SecondHand = false;

        public LockableStateUpdateHouseDoorMessage(): base()
        {
        }

        public LockableStateUpdateHouseDoorMessage(
            bool locked,
            int houseId,
            int instanceId,
            bool secondHand
        ): base(
            locked
        )
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            HouseId = reader.ReadVarInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
        }
    }
}