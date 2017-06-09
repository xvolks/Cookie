using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    public class HelloGameMessage : NetworkMessage
    {
        public const uint ProtocolId = 101;
        public override uint MessageID { get { return ProtocolId; } }

        public HelloGameMessage() { }

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
