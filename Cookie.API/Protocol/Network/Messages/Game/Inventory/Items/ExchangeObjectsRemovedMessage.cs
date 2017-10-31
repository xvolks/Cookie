namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Messages.Game.Inventory.Exchanges;
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
    {
        public new const ushort ProtocolId = 6532;
        public override ushort MessageID => ProtocolId;
        public List<uint> ObjectUID { get; set; }

        public ExchangeObjectsRemovedMessage(List<uint> objectUID)
        {
            ObjectUID = objectUID;
        }

        public ExchangeObjectsRemovedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)ObjectUID.Count);
            for (var objectUIDIndex = 0; objectUIDIndex < ObjectUID.Count; objectUIDIndex++)
            {
                writer.WriteVarUhInt(ObjectUID[objectUIDIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var objectUIDCount = reader.ReadUShort();
            ObjectUID = new List<uint>();
            for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++)
            {
                ObjectUID.Add(reader.ReadVarUhInt());
            }
        }

    }
}
