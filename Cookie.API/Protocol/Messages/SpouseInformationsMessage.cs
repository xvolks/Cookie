using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SpouseInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6356;

        public override ushort MessageID => ProtocolId;

        public FriendSpouseInformations Spouse { get; set; }
        public SpouseInformationsMessage() { }

        public SpouseInformationsMessage( FriendSpouseInformations Spouse ){
            this.Spouse = Spouse;
        }

        public override void Serialize(IDataWriter writer)
        {
            Spouse.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Spouse = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Spouse.Deserialize(reader);
        }
    }
}
