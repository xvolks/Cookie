namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Character.Alignment;
    using Types.Game.Context;
    using Types.Game.Look;
    using Utils.IO;

    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public new const ushort ProtocolId = 36;
        public override ushort TypeID => ProtocolId;
        public ActorAlignmentInformations AlignmentInfos { get; set; }

        public GameRolePlayCharacterInformations(ActorAlignmentInformations alignmentInfos)
        {
            AlignmentInfos = alignmentInfos;
        }

        public GameRolePlayCharacterInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
        }

    }
}
