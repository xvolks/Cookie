namespace Cookie.Protocol.Network.Messages.Game.Context
{
    using Cookie.IO;


    public class GameMapMovementConfirmMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 952;
        
        public override uint MessageID
        {
            get => ProtocolId;
        }
        
        public GameMapMovementConfirmMessage()
        {
        }
        
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
