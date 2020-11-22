using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayDelayedActionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6153;
        public override uint MessageID { get { return ProtocolId; } }

        public double DelayedCharacterId = 0;
        public byte DelayTypeId = 0;
        public double DelayEndTime = 0;

        public GameRolePlayDelayedActionMessage()
        {
        }

        public GameRolePlayDelayedActionMessage(
            double delayedCharacterId,
            byte delayTypeId,
            double delayEndTime
        )
        {
            DelayedCharacterId = delayedCharacterId;
            DelayTypeId = delayTypeId;
            DelayEndTime = delayEndTime;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(DelayedCharacterId);
            writer.WriteByte(DelayTypeId);
            writer.WriteDouble(DelayEndTime);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DelayedCharacterId = reader.ReadDouble();
            DelayTypeId = reader.ReadByte();
            DelayEndTime = reader.ReadDouble();
        }
    }
}