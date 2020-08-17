using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class MimicryObjectPreviewMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6458;

        public MimicryObjectPreviewMessage(ObjectItem result)
        {
            Result = result;
        }

        public MimicryObjectPreviewMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ObjectItem Result { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Result.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = new ObjectItem();
            Result.Deserialize(reader);
        }
    }
}