using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightEntityDispositionInformations : EntityDispositionInformations
    {
        public new const ushort ProtocolId = 217;

        public override ushort TypeID => ProtocolId;

        public double CarryingCharacterId { get; set; }
        public FightEntityDispositionInformations() { }

        public FightEntityDispositionInformations( double CarryingCharacterId ){
            this.CarryingCharacterId = CarryingCharacterId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(CarryingCharacterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CarryingCharacterId = reader.ReadDouble();
        }
    }
}
