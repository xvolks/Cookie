using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class QuestStepInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5625;

        public override ushort MessageID => ProtocolId;

        public QuestActiveInformations Infos { get; set; }
        public QuestStepInfoMessage() { }

        public QuestStepInfoMessage( QuestActiveInformations Infos ){
            this.Infos = Infos;
        }

        public override void Serialize(IDataWriter writer)
        {
            Infos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Infos = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Infos.Deserialize(reader);
        }
    }
}
