namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Spell
{
    using Utils.IO;

    public class SpellModifyFailureMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6653;
        public override ushort MessageID => ProtocolId;

        public SpellModifyFailureMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
