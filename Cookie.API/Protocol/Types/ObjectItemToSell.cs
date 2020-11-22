using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItemToSell : Item
    {
        public new const ushort ProtocolId = 120;

        public override ushort TypeID => ProtocolId;

        public ushort ObjectGID { get; set; }
        public List<ObjectEffect> Effects { get; set; }
        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }
        public ulong ObjectPrice { get; set; }
        public ObjectItemToSell() { }

        public ObjectItemToSell( ushort ObjectGID, List<ObjectEffect> Effects, uint ObjectUID, uint Quantity, ulong ObjectPrice ){
            this.ObjectGID = ObjectGID;
            this.Effects = Effects;
            this.ObjectUID = ObjectUID;
            this.Quantity = Quantity;
            this.ObjectPrice = ObjectPrice;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGID);
			writer.WriteShort((short)Effects.Count);
			foreach (var x in Effects)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
            writer.WriteVarUhLong(ObjectPrice);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUhShort();
            var EffectsCount = reader.ReadShort();
            Effects = new List<ObjectEffect>();
            for (var i = 0; i < EffectsCount; i++)
            {
                ObjectEffect objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Effects.Add(objectToAdd);
            }
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
            ObjectPrice = reader.ReadVarUhLong();
        }
    }
}
