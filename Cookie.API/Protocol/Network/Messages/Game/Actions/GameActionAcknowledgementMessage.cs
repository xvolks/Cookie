using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions
{
    public class GameActionAcknowledgementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 957;

        public GameActionAcknowledgementMessage(bool valid, sbyte actionId)
        {
            Valid = valid;
            ActionId = actionId;
        }

        public GameActionAcknowledgementMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Valid { get; set; }
        public sbyte ActionId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Valid);
            writer.WriteSByte(ActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Valid = reader.ReadBoolean();
            ActionId = reader.ReadSByte();
        }
    }
}