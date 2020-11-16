using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeGuildTaxCollectorGetMessage : NetworkMessage
    {
        public const uint ProtocolId = 5762;
        public override uint MessageID { get { return ProtocolId; } }

        public string CollectorName;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;
        public string UserName;
        public long CallerId = 0;
        public string CallerName;
        public double Experience = 0;
        public short Pods = 0;
        public List<ObjectItemGenericQuantity> ObjectsInfos;

        public ExchangeGuildTaxCollectorGetMessage()
        {
        }

        public ExchangeGuildTaxCollectorGetMessage(
            string collectorName,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId,
            string userName,
            long callerId,
            string callerName,
            double experience,
            short pods,
            List<ObjectItemGenericQuantity> objectsInfos
        )
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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(CollectorName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
            writer.WriteUTF(UserName);
            writer.WriteVarLong(CallerId);
            writer.WriteUTF(CallerName);
            writer.WriteDouble(Experience);
            writer.WriteVarShort(Pods);
            writer.WriteShort((short)ObjectsInfos.Count());
            foreach (var current in ObjectsInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CollectorName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
            UserName = reader.ReadUTF();
            CallerId = reader.ReadVarLong();
            CallerName = reader.ReadUTF();
            Experience = reader.ReadDouble();
            Pods = reader.ReadVarShort();
            var countObjectsInfos = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemGenericQuantity>();
            for (short i = 0; i < countObjectsInfos; i++)
            {
                ObjectItemGenericQuantity type = new ObjectItemGenericQuantity();
                type.Deserialize(reader);
                ObjectsInfos.Add(type);
            }
        }
    }
}