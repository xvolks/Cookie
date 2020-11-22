using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 148;

        public override ushort TypeID => ProtocolId;

        public TaxCollectorStaticInformations Identification { get; set; }
        public byte GuildLevel { get; set; }
        public int TaxCollectorAttack { get; set; }
        public GameRolePlayTaxCollectorInformations() { }

        public GameRolePlayTaxCollectorInformations( TaxCollectorStaticInformations Identification, byte GuildLevel, int TaxCollectorAttack ){
            this.Identification = Identification;
            this.GuildLevel = GuildLevel;
            this.TaxCollectorAttack = TaxCollectorAttack;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Identification.Serialize(writer);
            writer.WriteByte(GuildLevel);
            writer.WriteInt(TaxCollectorAttack);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Identification = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Identification.Deserialize(reader);
            GuildLevel = reader.ReadByte();
            TaxCollectorAttack = reader.ReadInt();
        }
    }
}
