using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountFeedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6189;

        public override ushort MessageID => ProtocolId;

        public uint MountUid { get; set; }
        public sbyte MountLocation { get; set; }
        public uint MountFoodUid { get; set; }
        public uint Quantity { get; set; }
        public MountFeedRequestMessage() { }

        public MountFeedRequestMessage( uint MountUid, sbyte MountLocation, uint MountFoodUid, uint Quantity ){
            this.MountUid = MountUid;
            this.MountLocation = MountLocation;
            this.MountFoodUid = MountFoodUid;
            this.Quantity = Quantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(MountUid);
            writer.WriteSByte(MountLocation);
            writer.WriteVarUhInt(MountFoodUid);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountUid = reader.ReadVarUhInt();
            MountLocation = reader.ReadSByte();
            MountFoodUid = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }
    }
}
