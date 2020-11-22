using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayDelayedActionFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6150;

        public override ushort MessageID => ProtocolId;

        public double DelayedCharacterId { get; set; }
        public sbyte DelayTypeId { get; set; }
        public GameRolePlayDelayedActionFinishedMessage() { }

        public GameRolePlayDelayedActionFinishedMessage( double DelayedCharacterId, sbyte DelayTypeId ){
            this.DelayedCharacterId = DelayedCharacterId;
            this.DelayTypeId = DelayTypeId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DelayedCharacterId);
            writer.WriteSByte(DelayTypeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DelayedCharacterId = reader.ReadDouble();
            DelayTypeId = reader.ReadSByte();
        }
    }
}
