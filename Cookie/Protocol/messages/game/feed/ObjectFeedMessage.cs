using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectFeedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6290;
        public override uint MessageID { get { return ProtocolId; } }

        public int ObjectUID = 0;
        public List<ObjectItemQuantity> Meal;

        public ObjectFeedMessage()
        {
        }

        public ObjectFeedMessage(
            int objectUID,
            List<ObjectItemQuantity> meal
        )
        {
            ObjectUID = objectUID;
            Meal = meal;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(ObjectUID);
            writer.WriteShort((short)Meal.Count());
            foreach (var current in Meal)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectUID = reader.ReadVarInt();
            var countMeal = reader.ReadShort();
            Meal = new List<ObjectItemQuantity>();
            for (short i = 0; i < countMeal; i++)
            {
                ObjectItemQuantity type = new ObjectItemQuantity();
                type.Deserialize(reader);
                Meal.Add(type);
            }
        }
    }
}