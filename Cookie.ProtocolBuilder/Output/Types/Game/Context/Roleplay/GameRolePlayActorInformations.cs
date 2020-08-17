namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Context;
    using Types.Game.Context;
    using Types.Game.Look;
    using Utils.IO;

    public class GameRolePlayActorInformations : GameContextActorInformations
    {
        public new const ushort ProtocolId = 141;
        public override ushort TypeID => ProtocolId;

        public GameRolePlayActorInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
