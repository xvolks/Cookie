using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CurrentMapInstanceMessage : CurrentMapMessage
    {
        public new const uint ProtocolId = 6738;
        public override uint MessageID { get { return ProtocolId; } }

        public double InstantiatedMapId = 0;

        public CurrentMapInstanceMessage(): base()
        {
        }

        public CurrentMapInstanceMessage(
            double mapId,
            string mapKey,
            double instantiatedMapId
        ): base(
            mapId,
            mapKey
        )
        {
            InstantiatedMapId = instantiatedMapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(InstantiatedMapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            InstantiatedMapId = reader.ReadDouble();
        }
    }
}