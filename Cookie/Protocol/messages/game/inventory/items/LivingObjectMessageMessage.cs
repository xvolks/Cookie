using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LivingObjectMessageMessage : NetworkMessage
    {
        public const uint ProtocolId = 6065;
        public override uint MessageID { get { return ProtocolId; } }

        public short MsgId = 0;
        public int TimeStamp = 0;
        public string Owner;
        public short ObjectGenericId = 0;

        public LivingObjectMessageMessage()
        {
        }

        public LivingObjectMessageMessage(
            short msgId,
            int timeStamp,
            string owner,
            short objectGenericId
        )
        {
            MsgId = msgId;
            TimeStamp = timeStamp;
            Owner = owner;
            ObjectGenericId = objectGenericId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(MsgId);
            writer.WriteInt(TimeStamp);
            writer.WriteUTF(Owner);
            writer.WriteVarShort(ObjectGenericId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MsgId = reader.ReadVarShort();
            TimeStamp = reader.ReadInt();
            Owner = reader.ReadUTF();
            ObjectGenericId = reader.ReadVarShort();
        }
    }
}