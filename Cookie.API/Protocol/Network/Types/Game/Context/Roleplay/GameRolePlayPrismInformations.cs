using Cookie.API.Protocol.Network.Types.Game.Prism;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GameRolePlayPrismInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 161;

        public GameRolePlayPrismInformations(PrismInformation prism)
        {
            Prism = prism;
        }

        public GameRolePlayPrismInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public PrismInformation Prism { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(Prism.TypeID);
            Prism.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadUShort());
            Prism.Deserialize(reader);
        }
    }
}