namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Arena
{
    using Types.Game.Character;
    using Utils.IO;

    public class ArenaFighterLeaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6700;
        public override ushort MessageID => ProtocolId;
        public CharacterBasicMinimalInformations Leaver { get; set; }

        public ArenaFighterLeaveMessage(CharacterBasicMinimalInformations leaver)
        {
            Leaver = leaver;
        }

        public ArenaFighterLeaveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Leaver.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Leaver = new CharacterBasicMinimalInformations();
            Leaver.Deserialize(reader);
        }

    }
}
