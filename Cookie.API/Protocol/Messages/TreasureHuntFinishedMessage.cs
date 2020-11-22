using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntFinishedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6483;

        public override ushort MessageID => ProtocolId;

        public sbyte QuestType { get; set; }
        public TreasureHuntFinishedMessage() { }

        public TreasureHuntFinishedMessage( sbyte QuestType ){
            this.QuestType = QuestType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(QuestType);
        }

        public override void Deserialize(IDataReader reader)
        {
            QuestType = reader.ReadSByte();
        }
    }
}
