using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeGuildTaxCollectorGetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5762;

        public ExchangeGuildTaxCollectorGetMessage(string collectorName, short worldX, short worldY, int mapId,
            ushort subAreaId, string userName, ulong callerId, string callerName, double experience, ushort pods,
            List<ObjectItemGenericQuantity> objectsInfos)
        {
            CollectorName = collectorName;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
            UserName = userName;
            CallerId = callerId;
            CallerName = callerName;
            Experience = experience;
            Pods = pods;
            ObjectsInfos = objectsInfos;
        }

        public ExchangeGuildTaxCollectorGetMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string CollectorName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public string UserName { get; set; }
        public ulong CallerId { get; set; }
        public string CallerName { get; set; }
        public double Experience { get; set; }
        public ushort Pods { get; set; }
        public List<ObjectItemGenericQuantity> ObjectsInfos { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(CollectorName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteUTF(UserName);
            writer.WriteVarUhLong(CallerId);
            writer.WriteUTF(CallerName);
            writer.WriteDouble(Experience);
            writer.WriteVarUhShort(Pods);
            writer.WriteShort((short) ObjectsInfos.Count);
            for (var objectsInfosIndex = 0; objectsInfosIndex < ObjectsInfos.Count; objectsInfosIndex++)
            {
                var objectToSend = ObjectsInfos[objectsInfosIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
            UserName = reader.ReadUTF();
            CallerId = reader.ReadVarUhLong();
            CallerName = reader.ReadUTF();
            Experience = reader.ReadDouble();
            Pods = reader.ReadVarUhShort();
            var objectsInfosCount = reader.ReadUShort();
            ObjectsInfos = new List<ObjectItemGenericQuantity>();
            for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
            {
                var objectToAdd = new ObjectItemGenericQuantity();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}