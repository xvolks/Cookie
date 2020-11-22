using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterCanBeCreatedResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6733;

        public override ushort MessageID => ProtocolId;

        public bool YesYouCan { get; set; }
        public CharacterCanBeCreatedResultMessage() { }

        public CharacterCanBeCreatedResultMessage( bool YesYouCan ){
            this.YesYouCan = YesYouCan;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(YesYouCan);
        }

        public override void Deserialize(IDataReader reader)
        {
            YesYouCan = reader.ReadBoolean();
        }
    }
}
