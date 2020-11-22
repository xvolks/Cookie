using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectItem : Item
    {
        public new const ushort ProtocolId = 37;

        public override ushort TypeID => ProtocolId;

        public short Position { get; set; }
        public ushort ObjectGID { get; set; }
        public List<ObjectEffect> Effects { get; set; }
        public uint ObjectUID { get; set; }
        public uint Quantity { get; set; }
        public ObjectItem() { }

        public ObjectItem( short Position, ushort ObjectGID, List<ObjectEffect> Effects, uint ObjectUID, uint Quantity ){
            this.Position = Position;
            this.ObjectGID = ObjectGID;
            this.Effects = Effects;
            this.ObjectUID = ObjectUID;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Position);
            writer.WriteVarUhShort(ObjectGID);
			writer.WriteShort((short)Effects.Count);
			foreach (var x in Effects)
			{
				x.Serialize(writer);
			}
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Position = reader.ReadShort();
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
        }
    }
}
