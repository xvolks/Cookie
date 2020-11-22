using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LivingObjectDissociateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5723;

        public override ushort MessageID => ProtocolId;

        public uint LivingUID { get; set; }
        public byte LivingPosition { get; set; }
        public LivingObjectDissociateMessage() { }

        public LivingObjectDissociateMessage( uint LivingUID, byte LivingPosition ){
            this.LivingUID = LivingUID;
            this.LivingPosition = LivingPosition;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(LivingUID);
            writer.WriteByte(LivingPosition);
        }

        public override void Deserialize(IDataReader reader)
        {
            LivingUID = reader.ReadVarUhInt();
            LivingPosition = reader.ReadByte();
        }
    }
}
