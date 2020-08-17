using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
    {
        public new const ushort ProtocolId = 107;

        public IdentifiedEntityDispositionInformations(double objectId)
        {
            ObjectId = objectId;
        }

        public IdentifiedEntityDispositionInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public double ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectId = reader.ReadDouble();
        }
    }
}