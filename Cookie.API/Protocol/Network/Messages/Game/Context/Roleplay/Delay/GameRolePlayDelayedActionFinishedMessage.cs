using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Delay
{
    public class GameRolePlayDelayedActionFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6150;

        public GameRolePlayDelayedActionFinishedMessage(double delayedCharacterId, byte delayTypeId)
        {
            DelayedCharacterId = delayedCharacterId;
            DelayTypeId = delayTypeId;
        }

        public GameRolePlayDelayedActionFinishedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double DelayedCharacterId { get; set; }
        public byte DelayTypeId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(DelayedCharacterId);
            writer.WriteByte(DelayTypeId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DelayedCharacterId = reader.ReadDouble();
            DelayTypeId = reader.ReadByte();
        }
    }
}