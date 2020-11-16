using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayDelayedActionFinishedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6150;
        public override uint MessageID { get { return ProtocolId; } }

        public double DelayedCharacterId = 0;
        public byte DelayTypeId = 0;

        public GameRolePlayDelayedActionFinishedMessage()
        {
        }

        public GameRolePlayDelayedActionFinishedMessage(
            double delayedCharacterId,
            byte delayTypeId
        )
        {
            DelayedCharacterId = delayedCharacterId;
            DelayTypeId = delayTypeId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(DelayedCharacterId);
            writer.WriteByte(DelayTypeId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DelayedCharacterId = reader.ReadDouble();
            DelayTypeId = reader.ReadByte();
        }
    }
}