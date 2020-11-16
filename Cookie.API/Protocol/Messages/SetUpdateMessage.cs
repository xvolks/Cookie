using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SetUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5503;

        public override ushort MessageID => ProtocolId;

        public ushort SetId { get; set; }
        public List<short> SetObjects { get; set; }
        public List<ObjectEffect> SetEffects { get; set; }
        public SetUpdateMessage() { }

        public SetUpdateMessage( ushort SetId, List<short> SetObjects, List<ObjectEffect> SetEffects ){
            this.SetId = SetId;
            this.SetObjects = SetObjects;
            this.SetEffects = SetEffects;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SetId);
			writer.WriteShort((short)SetObjects.Count);
			foreach (var x in SetObjects)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)SetEffects.Count);
			foreach (var x in SetEffects)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            SetId = reader.ReadVarUhShort();
            var SetObjectsCount = reader.ReadShort();
            SetObjects = new List<short>();
            for (var i = 0; i < SetObjectsCount; i++)
            {
                SetObjects.Add(reader.ReadVarShort());
            }
            var SetEffectsCount = reader.ReadShort();
            SetEffects = new List<ObjectEffect>();
            for (var i = 0; i < SetEffectsCount; i++)
            {
                ObjectEffect objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                SetEffects.Add(objectToAdd);
            }
        }
    }
}
