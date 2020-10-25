using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public new const short ProtocolId = 148;
        public override short TypeId { get { return ProtocolId; } }

        public TaxCollectorStaticInformations Identification;
        public byte GuildLevel = 0;
        public int TaxCollectorAttack = 0;

        public GameRolePlayTaxCollectorInformations(): base()
        {
        }

        public GameRolePlayTaxCollectorInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            TaxCollectorStaticInformations identification,
            byte guildLevel,
            int taxCollectorAttack
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            Identification = identification;
            GuildLevel = guildLevel;
            TaxCollectorAttack = taxCollectorAttack;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Identification.TypeId);
            Identification.Serialize(writer);
            writer.WriteByte(GuildLevel);
            writer.WriteInt(TaxCollectorAttack);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var identificationTypeId = reader.ReadShort();
            Identification = new TaxCollectorStaticInformations();
            Identification.Deserialize(reader);
            GuildLevel = reader.ReadByte();
            TaxCollectorAttack = reader.ReadInt();
        }
    }
}