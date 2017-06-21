using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Context
{
    public class GameMapMovementConfirmMessage : NetworkMessage
    {
        public const uint ProtocolId = 952;

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            //
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            //
        }
    }
}