namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party.Companion
{
    using Types.Game.Look;
    using Utils.IO;

    public class PartyCompanionMemberInformations : PartyCompanionBaseInformations
    {
        public new const ushort ProtocolId = 452;
        public override ushort TypeID => ProtocolId;
        public ushort Initiative { get; set; }
        public uint LifePoints { get; set; }
        public uint MaxLifePoints { get; set; }
        public ushort Prospecting { get; set; }
        public byte RegenRate { get; set; }

        public PartyCompanionMemberInformations(ushort initiative, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate)
        {
            Initiative = initiative;
            LifePoints = lifePoints;
            MaxLifePoints = maxLifePoints;
            Prospecting = prospecting;
            RegenRate = regenRate;
        }

        public PartyCompanionMemberInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Initiative);
            writer.WriteVarUhInt(LifePoints);
            writer.WriteVarUhInt(MaxLifePoints);
            writer.WriteVarUhShort(Prospecting);
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Initiative = reader.ReadVarUhShort();
            LifePoints = reader.ReadVarUhInt();
            MaxLifePoints = reader.ReadVarUhInt();
            Prospecting = reader.ReadVarUhShort();
            RegenRate = reader.ReadByte();
        }

    }
}
