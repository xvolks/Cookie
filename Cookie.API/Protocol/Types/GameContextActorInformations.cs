using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameContextActorInformations : NetworkType
    {
        public const ushort ProtocolId = 150;

        public override ushort TypeID => ProtocolId;

        public double ContextualId { get; set; }
        public EntityLook Look { get; set; }
        public EntityDispositionInformations Disposition { get; set; }
        public GameContextActorInformations() { }

        public GameContextActorInformations( double ContextualId, EntityLook Look, EntityDispositionInformations Disposition ){
            this.ContextualId = ContextualId;
            this.Look = Look;
            this.Disposition = Disposition;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ContextualId);
            Look.Serialize(writer);
            Disposition.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ContextualId = reader.ReadDouble();
            Look = new EntityLook();
            Look.Deserialize(reader);
            Disposition = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Disposition.Deserialize(reader);
        }
    }
}
