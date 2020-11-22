using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeGuildTaxCollectorGetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5762;

        public override ushort MessageID => ProtocolId;

        public string CollectorName { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public string UserName { get; set; }
        public ulong CallerId { get; set; }
        public string CallerName { get; set; }
        public double Experience { get; set; }
        public ushort Pods { get; set; }
        public List<ObjectItemGenericQuantity> ObjectsInfos { get; set; }
        public ExchangeGuildTaxCollectorGetMessage() { }

        public ExchangeGuildTaxCollectorGetMessage( string CollectorName, short WorldX, short WorldY, double MapId, ushort SubAreaId, string UserName, ulong CallerId, string CallerName, double Experience, ushort Pods, List<ObjectItemGenericQuantity> ObjectsInfos ){
            this.CollectorName = CollectorName;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
            this.UserName = UserName;
            this.CallerId = CallerId;
            this.CallerName = CallerName;
            this.Experience = Experience;
            this.Pods = Pods;
            this.ObjectsInfos = ObjectsInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(CollectorName);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteUTF(UserName);
            writer.WriteVarUhLong(CallerId);
            writer.WriteUTF(CallerName);
            writer.WriteDouble(Experience);
            writer.WriteVarUhShort(Pods);
			writer.WriteShort((short)ObjectsInfos.Count);
			foreach (var x in ObjectsInfos)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorName = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
            UserName = reader.ReadUTF();
            CallerId = reader.ReadVarUhLong();
            CallerName = reader.ReadUTF();
            Experience = reader.ReadDouble();
            Pods = reader.ReadVarUhShort();
            var ObjectsInfosCount = reader.ReadShort();
            ObjectsInfos = new List<ObjectItemGenericQuantity>();
            for (var i = 0; i < ObjectsInfosCount; i++)
            {
                var objectToAdd = new ObjectItemGenericQuantity();
                objectToAdd.Deserialize(reader);
                ObjectsInfos.Add(objectToAdd);
            }
        }
    }
}
