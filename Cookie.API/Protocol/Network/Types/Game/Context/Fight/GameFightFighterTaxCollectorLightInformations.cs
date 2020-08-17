using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
    {
        public new const ushort ProtocolId = 457;

        public GameFightFighterTaxCollectorLightInformations(ushort firstNameId, ushort lastNameId)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
        }

        public GameFightFighterTaxCollectorLightInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
        }
    }
}