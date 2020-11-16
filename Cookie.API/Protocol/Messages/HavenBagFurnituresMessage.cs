using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HavenBagFurnituresMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6634;

        public override ushort MessageID => ProtocolId;

        public List<HavenBagFurnitureInformation> FurnituresInfos { get; set; }
        public HavenBagFurnituresMessage() { }

        public HavenBagFurnituresMessage( List<HavenBagFurnitureInformation> FurnituresInfos ){
            this.FurnituresInfos = FurnituresInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)FurnituresInfos.Count);
			foreach (var x in FurnituresInfos)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FurnituresInfosCount = reader.ReadShort();
            FurnituresInfos = new List<HavenBagFurnitureInformation>();
            for (var i = 0; i < FurnituresInfosCount; i++)
            {
                var objectToAdd = new HavenBagFurnitureInformation();
                objectToAdd.Deserialize(reader);
                FurnituresInfos.Add(objectToAdd);
            }
        }
    }
}
