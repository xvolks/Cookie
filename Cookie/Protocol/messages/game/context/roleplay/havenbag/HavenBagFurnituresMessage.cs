using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class HavenBagFurnituresMessage : NetworkMessage
    {
        public const uint ProtocolId = 6634;
        public override uint MessageID { get { return ProtocolId; } }

        public List<HavenBagFurnitureInformation> FurnituresInfos;

        public HavenBagFurnituresMessage()
        {
        }

        public HavenBagFurnituresMessage(
            List<HavenBagFurnitureInformation> furnituresInfos
        )
        {
            FurnituresInfos = furnituresInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)FurnituresInfos.Count());
            foreach (var current in FurnituresInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFurnituresInfos = reader.ReadShort();
            FurnituresInfos = new List<HavenBagFurnitureInformation>();
            for (short i = 0; i < countFurnituresInfos; i++)
            {
                HavenBagFurnitureInformation type = new HavenBagFurnitureInformation();
                type.Deserialize(reader);
                FurnituresInfos.Add(type);
            }
        }
    }
}