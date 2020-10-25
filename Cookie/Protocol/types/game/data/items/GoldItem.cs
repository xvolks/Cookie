using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GoldItem : Item
    {
        public new const short ProtocolId = 123;
        public override short TypeId { get { return ProtocolId; } }

        public long Sum = 0;

        public GoldItem(): base()
        {
        }

        public GoldItem(
            long sum
        ): base()
        {
            Sum = sum;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(Sum);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Sum = reader.ReadVarLong();
        }
    }
}