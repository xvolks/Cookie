using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class UpdateMountCharacteristicsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6753;

        public override ushort MessageID => ProtocolId;

        public int RideId { get; set; }
        public List<UpdateMountCharacteristic> BoostToUpdateList { get; set; }
        public UpdateMountCharacteristicsMessage() { }

        public UpdateMountCharacteristicsMessage( int RideId, List<UpdateMountCharacteristic> BoostToUpdateList ){
            this.RideId = RideId;
            this.BoostToUpdateList = BoostToUpdateList;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(RideId);
			writer.WriteShort((short)BoostToUpdateList.Count);
			foreach (var x in BoostToUpdateList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            RideId = reader.ReadVarInt();
            var BoostToUpdateListCount = reader.ReadShort();
            BoostToUpdateList = new List<UpdateMountCharacteristic>();
            for (var i = 0; i < BoostToUpdateListCount; i++)
            {
                UpdateMountCharacteristic objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                BoostToUpdateList.Add(objectToAdd);
            }
        }
    }
}
