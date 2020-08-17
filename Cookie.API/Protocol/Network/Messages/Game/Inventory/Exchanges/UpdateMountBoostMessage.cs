using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Mount;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class UpdateMountBoostMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6179;

        public UpdateMountBoostMessage(int rideId, List<UpdateMountBoost> boostToUpdateList)
        {
            RideId = rideId;
            BoostToUpdateList = boostToUpdateList;
        }

        public UpdateMountBoostMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int RideId { get; set; }
        public List<UpdateMountBoost> BoostToUpdateList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(RideId);
            writer.WriteShort((short) BoostToUpdateList.Count);
            for (var boostToUpdateListIndex = 0;
                boostToUpdateListIndex < BoostToUpdateList.Count;
                boostToUpdateListIndex++)
            {
                var objectToSend = BoostToUpdateList[boostToUpdateListIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            RideId = reader.ReadVarInt();
            var boostToUpdateListCount = reader.ReadUShort();
            BoostToUpdateList = new List<UpdateMountBoost>();
            for (var boostToUpdateListIndex = 0;
                boostToUpdateListIndex < boostToUpdateListCount;
                boostToUpdateListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<UpdateMountBoost>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                BoostToUpdateList.Add(objectToAdd);
            }
        }
    }
}