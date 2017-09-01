namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class ShowCellSpectatorMessage : ShowCellMessage
    {
        public new const ushort ProtocolId = 6158;
        public override ushort MessageID => ProtocolId;
        public string PlayerName { get; set; }

        public ShowCellSpectatorMessage(string playerName)
        {
            PlayerName = playerName;
        }

        public ShowCellSpectatorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerName = reader.ReadUTF();
        }

    }
}
