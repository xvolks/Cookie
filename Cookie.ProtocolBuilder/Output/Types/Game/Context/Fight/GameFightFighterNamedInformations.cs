namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Character.Status;
    using Types.Game.Context;
    using Types.Game.Look;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightFighterNamedInformations : GameFightFighterInformations
    {
        public new const ushort ProtocolId = 158;
        public override ushort TypeID => ProtocolId;
        public string Name { get; set; }
        public PlayerStatus Status { get; set; }

        public GameFightFighterNamedInformations(string name, PlayerStatus status)
        {
            Name = name;
            Status = status;
        }

        public GameFightFighterNamedInformations() { }

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
