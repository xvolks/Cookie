namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Types.Game.Context;
    using Utils.IO;

    public class GameContextMoveElementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 253;
        public override ushort MessageID => ProtocolId;
        public EntityMovementInformations Movement { get; set; }

        public GameContextMoveElementMessage(EntityMovementInformations movement)
        {
            Movement = movement;
        }

        public GameContextMoveElementMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            Movement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Movement = new EntityMovementInformations();
            Movement.Deserialize(reader);
        }

    }
}
