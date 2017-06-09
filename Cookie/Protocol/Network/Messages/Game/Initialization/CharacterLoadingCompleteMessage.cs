using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Initialization
{
    public class CharacterLoadingCompleteMessage : NetworkMessage
    {
        public const uint ProtocolId = 6471;
        public override uint MessageID { get { return ProtocolId; } }

        public CharacterLoadingCompleteMessage() { }

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
