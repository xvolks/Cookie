using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameContextActorInformations : NetworkType
    {
        public const short ProtocolId = 150;
        public override short TypeId { get { return ProtocolId; } }

        public double ContextualId = 0;
        public EntityLook Look;
        public EntityDispositionInformations Disposition;

        public GameContextActorInformations()
        {
        }

        public GameContextActorInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition
        )
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(ContextualId);
            Look.Serialize(writer);
            writer.WriteShort(Disposition.TypeId);
            Disposition.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ContextualId = reader.ReadDouble();
            Look = new EntityLook();
            Look.Deserialize(reader);
            var dispositionTypeId = reader.ReadShort();
            Disposition = new EntityDispositionInformations();
            Disposition.Deserialize(reader);
        }
    }
}