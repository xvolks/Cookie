using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
    {
        public new const ushort ProtocolId = 203;

        public override ushort TypeID => ProtocolId;

        public ActorAlignmentInformations AlignmentInfos { get; set; }
        public GameFightMonsterWithAlignmentInformations() { }

        public GameFightMonsterWithAlignmentInformations( ActorAlignmentInformations AlignmentInfos ){
            this.AlignmentInfos = AlignmentInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
        }
    }
}
