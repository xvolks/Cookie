namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using Utils.IO;

    public class AlliancePrismDialogQuestionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6448;
        public override ushort MessageID => ProtocolId;

        public AlliancePrismDialogQuestionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
