using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayDelayedActionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6153;

        public override ushort MessageID => ProtocolId;

        public double DelayedCharacterId { get; set; }
        public sbyte DelayTypeId { get; set; }
        public double DelayEndTime { get; set; }
        public GameRolePlayDelayedActionMessage() { }

        public GameRolePlayDelayedActionMessage( double DelayedCharacterId, sbyte DelayTypeId, double DelayEndTime ){
            this.DelayedCharacterId = DelayedCharacterId;
            this.DelayTypeId = DelayTypeId;
            this.DelayEndTime = DelayEndTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DelayedCharacterId);
            writer.WriteSByte(DelayTypeId);
            writer.WriteDouble(DelayEndTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            DelayedCharacterId = reader.ReadDouble();
            DelayTypeId = reader.ReadSByte();
            DelayEndTime = reader.ReadDouble();
        }
    }
}
