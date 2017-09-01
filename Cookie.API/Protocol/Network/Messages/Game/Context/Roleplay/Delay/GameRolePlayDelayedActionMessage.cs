using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Delay
{
    public class GameRolePlayDelayedActionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6153;

        public GameRolePlayDelayedActionMessage(double delayedCharacterId, byte delayTypeId, double delayEndTime)
        {
            DelayedCharacterId = delayedCharacterId;
            DelayTypeId = delayTypeId;
            DelayEndTime = delayEndTime;
        }

        public GameRolePlayDelayedActionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double DelayedCharacterId { get; set; }
        public byte DelayTypeId { get; set; }
        public double DelayEndTime { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DelayedCharacterId);
            writer.WriteByte(DelayTypeId);
            writer.WriteDouble(DelayEndTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            DelayedCharacterId = reader.ReadDouble();
            DelayTypeId = reader.ReadByte();
            DelayEndTime = reader.ReadDouble();
        }
    }
}