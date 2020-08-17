using Cookie.API.Protocol.Network.Types.Game.Character.Status;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightFighterNamedInformations : GameFightFighterInformations
    {
        public new const ushort ProtocolId = 158;

        public GameFightFighterNamedInformations(string name, PlayerStatus status)
        {
            Name = name;
            Status = status;
        }

        public GameFightFighterNamedInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string Name { get; set; }
        public PlayerStatus Status { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
        }
    }
}