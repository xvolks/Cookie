using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionAlliance : HumanOption
    {
        public new const ushort ProtocolId = 425;

        public override ushort TypeID => ProtocolId;

        public AllianceInformations AllianceInformations { get; set; }
        public sbyte Aggressable { get; set; }
        public HumanOptionAlliance() { }

        public HumanOptionAlliance( AllianceInformations AllianceInformations, sbyte Aggressable ){
            this.AllianceInformations = AllianceInformations;
            this.Aggressable = Aggressable;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AllianceInformations.Serialize(writer);
            writer.WriteSByte(Aggressable);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceInformations = new AllianceInformations();
            AllianceInformations.Deserialize(reader);
            Aggressable = reader.ReadSByte();
        }
    }
}
