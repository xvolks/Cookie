using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Status
{
    public class PlayerStatusExtended : PlayerStatus
    {
        public new const ushort ProtocolId = 414;

        public PlayerStatusExtended(string message)
        {
            Message = message;
        }

        public PlayerStatusExtended()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string Message { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Message);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Message = reader.ReadUTF();
        }
    }
}