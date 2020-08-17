using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
    {
        public new const ushort ProtocolId = 5668;

        public LockableStateUpdateHouseDoorMessage(uint houseId, int instanceId, bool secondHand)
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
        }

        public LockableStateUpdateHouseDoorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }

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