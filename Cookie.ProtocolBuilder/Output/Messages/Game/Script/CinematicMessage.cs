namespace Cookie.API.Protocol.Network.Messages.Game.Script
{
    using Utils.IO;

    public class CinematicMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6053;
        public override ushort MessageID => ProtocolId;
        public ushort CinematicId { get; set; }

        public CinematicMessage(ushort cinematicId)
        {
            CinematicId = cinematicId;
        }

        public CinematicMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CinematicId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CinematicId = reader.ReadVarUhShort();
        }

    }
}
