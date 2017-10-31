namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Objects
{
    using Utils.IO;

    public class ObjectGroundAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3017;
        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }
        public ushort ObjectGID { get; set; }

        public ObjectGroundAddedMessage(ushort cellId, ushort objectGID)
        {
            CellId = cellId;
            ObjectGID = objectGID;
        }

        public ObjectGroundAddedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
            ObjectGID = reader.ReadVarUhShort();
        }

    }
}
