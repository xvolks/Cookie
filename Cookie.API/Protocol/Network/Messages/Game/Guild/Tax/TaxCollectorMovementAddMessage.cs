using Cookie.API.Protocol.Network.Types.Game.Guild.Tax;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class TaxCollectorMovementAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5917;

        public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
        {
            Informations = informations;
        }

        public TaxCollectorMovementAddMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public TaxCollectorInformations Informations { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Informations.TypeID);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadUShort());
            Informations.Deserialize(reader);
        }
    }
}