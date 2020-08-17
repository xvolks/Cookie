using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Death
{
    public class GameRolePlayPlayerLifeStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5996;

        public GameRolePlayPlayerLifeStatusMessage(byte state, int phenixMapId)
        {
            State = state;
            PhenixMapId = phenixMapId;
        }

        public GameRolePlayPlayerLifeStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte State { get; set; }
        public int PhenixMapId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(State);
            writer.WriteInt(PhenixMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            State = reader.ReadByte();
            PhenixMapId = reader.ReadInt();
        }
    }
}