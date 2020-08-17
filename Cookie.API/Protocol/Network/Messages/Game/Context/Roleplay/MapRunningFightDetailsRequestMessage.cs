using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapRunningFightDetailsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5750;

        public MapRunningFightDetailsRequestMessage(int fightId)
        {
            FightId = fightId;
        }

        public MapRunningFightDetailsRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
        }
    }
}