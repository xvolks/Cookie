using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class UpdateMountCharacteristicsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6753;
        public override uint MessageID { get { return ProtocolId; } }

        public int RideId = 0;
        public List<UpdateMountCharacteristic> BoostToUpdateList;

        public UpdateMountCharacteristicsMessage()
        {
        }

        public UpdateMountCharacteristicsMessage(
            int rideId,
            List<UpdateMountCharacteristic> boostToUpdateList
        )
        {
            RideId = rideId;
            BoostToUpdateList = boostToUpdateList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(RideId);
            writer.WriteShort((short)BoostToUpdateList.Count());
            foreach (var current in BoostToUpdateList)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RideId = reader.ReadVarInt();
            var countBoostToUpdateList = reader.ReadShort();
            BoostToUpdateList = new List<UpdateMountCharacteristic>();
            for (short i = 0; i < countBoostToUpdateList; i++)
            {
                var boostToUpdateListtypeId = reader.ReadShort();
                UpdateMountCharacteristic type = new UpdateMountCharacteristic();
                type.Deserialize(reader);
                BoostToUpdateList.Add(type);
            }
        }
    }
}