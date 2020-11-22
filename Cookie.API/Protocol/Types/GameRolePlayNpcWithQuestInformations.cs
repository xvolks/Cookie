using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
    {
        public new const ushort ProtocolId = 383;

        public override ushort TypeID => ProtocolId;

        public GameRolePlayNpcQuestFlag QuestFlag { get; set; }
        public GameRolePlayNpcWithQuestInformations() { }

        public GameRolePlayNpcWithQuestInformations( GameRolePlayNpcQuestFlag QuestFlag ){
            this.QuestFlag = QuestFlag;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            QuestFlag.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            QuestFlag = new GameRolePlayNpcQuestFlag();
            QuestFlag.Deserialize(reader);
        }
    }
}
