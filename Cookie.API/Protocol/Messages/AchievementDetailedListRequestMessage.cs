using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AchievementDetailedListRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6357;

        public override ushort MessageID => ProtocolId;

        public ushort CategoryId { get; set; }
        public AchievementDetailedListRequestMessage() { }

        public AchievementDetailedListRequestMessage( ushort CategoryId ){
            this.CategoryId = CategoryId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CategoryId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CategoryId = reader.ReadVarUhShort();
        }
    }
}
