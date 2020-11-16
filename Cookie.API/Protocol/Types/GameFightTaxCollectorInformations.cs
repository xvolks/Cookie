using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public new const ushort ProtocolId = 48;

        public override ushort TypeID => ProtocolId;

        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public byte Level { get; set; }
        public GameFightTaxCollectorInformations() { }

        public GameFightTaxCollectorInformations( ushort FirstNameId, ushort LastNameId, byte Level ){
            this.FirstNameId = FirstNameId;
            this.LastNameId = LastNameId;
            this.Level = Level;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            Level = reader.ReadByte();
        }
    }
}
