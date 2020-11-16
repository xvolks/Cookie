using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LivingObjectChangeSkinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5725;

        public override ushort MessageID => ProtocolId;

        public uint LivingUID { get; set; }
        public byte LivingPosition { get; set; }
        public uint SkinId { get; set; }
        public LivingObjectChangeSkinRequestMessage() { }

        public LivingObjectChangeSkinRequestMessage( uint LivingUID, byte LivingPosition, uint SkinId ){
            this.LivingUID = LivingUID;
            this.LivingPosition = LivingPosition;
            this.SkinId = SkinId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(LivingUID);
            writer.WriteByte(LivingPosition);
            writer.WriteVarUhInt(SkinId);
        }

        public override void Deserialize(IDataReader reader)
        {
            LivingUID = reader.ReadVarUhInt();
            LivingPosition = reader.ReadByte();
            SkinId = reader.ReadVarUhInt();
        }
    }
}
