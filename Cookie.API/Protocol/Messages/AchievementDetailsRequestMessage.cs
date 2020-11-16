using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AchievementDetailsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6380;

        public override ushort MessageID => ProtocolId;

        public ushort AchievementId { get; set; }
        public AchievementDetailsRequestMessage() { }

        public AchievementDetailsRequestMessage( ushort AchievementId ){
            this.AchievementId = AchievementId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(AchievementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AchievementId = reader.ReadVarUhShort();
        }
    }
}
