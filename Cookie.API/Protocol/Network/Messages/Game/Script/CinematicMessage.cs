using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Script
{
    public class CinematicMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6053;

        public CinematicMessage(ushort cinematicId)
        {
            CinematicId = cinematicId;
        }

        public CinematicMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort CinematicId { get; set; }

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