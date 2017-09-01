using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GameRolePlayPortalInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 467;

        public GameRolePlayPortalInformations(PortalInformation portal)
        {
            Portal = portal;
        }

        public GameRolePlayPortalInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public PortalInformation Portal { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(Portal.TypeID);
            Portal.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Portal = ProtocolTypeManager.GetInstance<PortalInformation>(reader.ReadUShort());
            Portal.Deserialize(reader);
        }
    }
}