namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    using Utils.IO;

    public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
    {
        public new const ushort ProtocolId = 5669;
        public override ushort MessageID => ProtocolId;
        public double MapId { get; set; }
        public uint ElementId { get; set; }

        public LockableStateUpdateStorageMessage(double mapId, uint elementId)
        {
            MapId = mapId;
            ElementId = elementId;
        }

        public LockableStateUpdateStorageMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(MapId);
            writer.WriteVarUhInt(ElementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MapId = reader.ReadDouble();
            ElementId = reader.ReadVarUhInt();
        }

    }
}
