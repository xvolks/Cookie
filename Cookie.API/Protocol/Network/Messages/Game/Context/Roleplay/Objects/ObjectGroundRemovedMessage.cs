namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Objects
{
    using Utils.IO;

    public class ObjectGroundRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3014;
        public override ushort MessageID => ProtocolId;
        public ushort Cell { get; set; }

        public ObjectGroundRemovedMessage(ushort cell)
        {
            Cell = cell;
        }

        public ObjectGroundRemovedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Cell);
        }

        public override void Deserialize(IDataReader reader)
        {
            Cell = reader.ReadVarUhShort();
        }

    }
}
