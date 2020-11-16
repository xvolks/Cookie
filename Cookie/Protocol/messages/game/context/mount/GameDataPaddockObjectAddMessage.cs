using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameDataPaddockObjectAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 5990;
        public override uint MessageID { get { return ProtocolId; } }

        public PaddockItem PaddockItemDescription;

        public GameDataPaddockObjectAddMessage()
        {
        }

        public GameDataPaddockObjectAddMessage(
            PaddockItem paddockItemDescription
        )
        {
            PaddockItemDescription = paddockItemDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            PaddockItemDescription.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PaddockItemDescription = new PaddockItem();
            PaddockItemDescription.Deserialize(reader);
        }
    }
}