using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectFeedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6290;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public List<ObjectItemQuantity> Meal { get; set; }
        public ObjectFeedMessage() { }

        public ObjectFeedMessage( uint ObjectUID, List<ObjectItemQuantity> Meal ){
            this.ObjectUID = ObjectUID;
            this.Meal = Meal;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
			writer.WriteShort((short)Meal.Count);
			foreach (var x in Meal)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            var MealCount = reader.ReadShort();
            Meal = new List<ObjectItemQuantity>();
            for (var i = 0; i < MealCount; i++)
            {
                var objectToAdd = new ObjectItemQuantity();
                objectToAdd.Deserialize(reader);
                Meal.Add(objectToAdd);
            }
        }
    }
}
