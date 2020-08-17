namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    using System.Collections.Generic;
    using Utils.IO;

    public class ZaapListMessage : TeleportDestinationsListMessage
    {
        public new const ushort ProtocolId = 1604;
        public override ushort MessageID => ProtocolId;
        public double SpawnMapId { get; set; }

        public ZaapListMessage(double spawnMapId)
        {
            SpawnMapId = spawnMapId;
        }

        public ZaapListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(SpawnMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpawnMapId = reader.ReadDouble();
        }

    }
}
