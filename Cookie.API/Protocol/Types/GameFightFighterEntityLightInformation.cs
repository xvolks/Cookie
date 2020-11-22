using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightFighterEntityLightInformation : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 548;

        public override ushort TypeID => ProtocolId;

        public sbyte EntityModelId { get; set; }
        public double MasterId { get; set; }
        public GameFightFighterEntityLightInformation() { }

        public GameFightFighterEntityLightInformation( sbyte EntityModelId, double MasterId ){
            this.EntityModelId = EntityModelId;
            this.MasterId = MasterId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(EntityModelId);
            writer.WriteDouble(MasterId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EntityModelId = reader.ReadSByte();
            MasterId = reader.ReadDouble();
        }
    }
}
