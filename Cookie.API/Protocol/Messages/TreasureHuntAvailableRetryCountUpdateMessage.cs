using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntAvailableRetryCountUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6491;

        public override ushort MessageID => ProtocolId;

        public sbyte QuestType { get; set; }
        public int AvailableRetryCount { get; set; }
        public TreasureHuntAvailableRetryCountUpdateMessage() { }

        public TreasureHuntAvailableRetryCountUpdateMessage( sbyte QuestType, int AvailableRetryCount ){
            this.QuestType = QuestType;
            this.AvailableRetryCount = AvailableRetryCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
            writer.WriteInt(AvailableRetryCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
            AvailableRetryCount = reader.ReadInt();
        }
    }
}
