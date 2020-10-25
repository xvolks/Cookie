using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SpouseInformationsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6356;
        public override uint MessageID { get { return ProtocolId; } }

        public FriendSpouseInformations Spouse;

        public SpouseInformationsMessage()
        {
        }

        public SpouseInformationsMessage(
            FriendSpouseInformations spouse
        )
        {
            Spouse = spouse;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Spouse.TypeId);
            Spouse.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var spouseTypeId = reader.ReadShort();
            Spouse = new FriendSpouseInformations();
            Spouse.Deserialize(reader);
        }
    }
}