using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class LivingObjectMessageMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6065;

        public LivingObjectMessageMessage(ushort msgId, int timeStamp, string owner, ushort objectGenericId)
        {
            MsgId = msgId;
            TimeStamp = timeStamp;
            Owner = owner;
            ObjectGenericId = objectGenericId;
        }

        public LivingObjectMessageMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort MsgId { get; set; }
        public int TimeStamp { get; set; }
        public string Owner { get; set; }
        public ushort ObjectGenericId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(MsgId);
            writer.WriteInt(TimeStamp);
            writer.WriteUTF(Owner);
            writer.WriteVarUhShort(ObjectGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgId = reader.ReadVarUhShort();
            TimeStamp = reader.ReadInt();
            Owner = reader.ReadUTF();
            ObjectGenericId = reader.ReadVarUhShort();
        }
    }
}