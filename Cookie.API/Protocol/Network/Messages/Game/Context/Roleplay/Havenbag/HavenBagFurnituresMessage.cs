using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Guild;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    public class HavenBagFurnituresMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6634;

        public HavenBagFurnituresMessage(List<HavenBagFurnitureInformation> furnituresInfos)
        {
            FurnituresInfos = furnituresInfos;
        }

        public HavenBagFurnituresMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<HavenBagFurnitureInformation> FurnituresInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) FurnituresInfos.Count);
            for (var furnituresInfosIndex = 0; furnituresInfosIndex < FurnituresInfos.Count; furnituresInfosIndex++)
            {
                var objectToSend = FurnituresInfos[furnituresInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var furnituresInfosCount = reader.ReadUShort();
            FurnituresInfos = new List<HavenBagFurnitureInformation>();
            for (var furnituresInfosIndex = 0; furnituresInfosIndex < furnituresInfosCount; furnituresInfosIndex++)
            {
                var objectToAdd = new HavenBagFurnitureInformation();
                objectToAdd.Deserialize(reader);
                FurnituresInfos.Add(objectToAdd);
            }
        }
    }
}