using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightMutantInformations : GameFightFighterNamedInformations
    {
        public new const ushort ProtocolId = 50;

        public override ushort TypeID => ProtocolId;

        public sbyte PowerLevel { get; set; }
        public GameFightMutantInformations() { }

        public GameFightMutantInformations( sbyte PowerLevel ){
            this.PowerLevel = PowerLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(PowerLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PowerLevel = reader.ReadSByte();
        }
    }
}
