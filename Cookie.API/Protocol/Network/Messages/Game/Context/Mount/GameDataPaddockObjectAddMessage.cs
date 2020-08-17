using Cookie.API.Protocol.Network.Types.Game.Paddock;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class GameDataPaddockObjectAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5990;

        public GameDataPaddockObjectAddMessage(PaddockItem paddockItemDescription)
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public GameDataPaddockObjectAddMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public PaddockItem PaddockItemDescription { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            PaddockItemDescription.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockItemDescription = new PaddockItem();
            PaddockItemDescription.Deserialize(reader);
        }
    }
}