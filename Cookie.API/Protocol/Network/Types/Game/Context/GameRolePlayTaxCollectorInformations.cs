using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 148;

        public GameRolePlayTaxCollectorInformations(TaxCollectorStaticInformations identification, byte guildLevel,
            int taxCollectorAttack)
        {
            Identification = identification;
            GuildLevel = guildLevel;
            TaxCollectorAttack = taxCollectorAttack;
        }

        public GameRolePlayTaxCollectorInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public TaxCollectorStaticInformations Identification { get; set; }
        public byte GuildLevel { get; set; }
        public int TaxCollectorAttack { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(Identification.TypeID);
            Identification.Serialize(writer);
            writer.WriteByte(GuildLevel);
            writer.WriteInt(TaxCollectorAttack);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Identification = ProtocolTypeManager.GetInstance<TaxCollectorStaticInformations>(reader.ReadUShort());
            Identification.Deserialize(reader);
            GuildLevel = reader.ReadByte();
            TaxCollectorAttack = reader.ReadInt();
        }
    }
}