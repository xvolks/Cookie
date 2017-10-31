namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using System.Collections.Generic;
    using Utils.IO;

    public class GameCautiousMapMovementRequestMessage : GameMapMovementRequestMessage
    {
        public new const ushort ProtocolId = 6496;
        public override ushort MessageID => ProtocolId;

        public GameCautiousMapMovementRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
