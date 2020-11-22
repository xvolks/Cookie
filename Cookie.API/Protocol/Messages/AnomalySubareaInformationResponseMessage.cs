using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AnomalySubareaInformationResponseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6836;

        public override ushort MessageID => ProtocolId;

        public List<AnomalySubareaInformation> Subareas { get; set; }
        public AnomalySubareaInformationResponseMessage() { }

        public AnomalySubareaInformationResponseMessage( List<AnomalySubareaInformation> Subareas ){
            this.Subareas = Subareas;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Subareas.Count);
			foreach (var x in Subareas)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var SubareasCount = reader.ReadShort();
            Subareas = new List<AnomalySubareaInformation>();
            for (var i = 0; i < SubareasCount; i++)
            {
                var objectToAdd = new AnomalySubareaInformation();
                objectToAdd.Deserialize(reader);
                Subareas.Add(objectToAdd);
            }
        }
    }
}
