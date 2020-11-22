using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public new const ushort ProtocolId = 36;

        public override ushort TypeID => ProtocolId;

        public ActorAlignmentInformations AlignmentInfos { get; set; }
        public uint Speed { get; set; }
        public GameRolePlayCharacterInformations() { }

        public GameRolePlayCharacterInformations( ActorAlignmentInformations AlignmentInfos, uint Speed ){
            this.AlignmentInfos = AlignmentInfos;
            this.Speed = Speed;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            AlignmentInfos.Serialize(writer);
            writer.WriteVarUhInt(Speed);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AlignmentInfos = new ActorAlignmentInformations();
            AlignmentInfos.Deserialize(reader);
            Speed = reader.ReadVarUhInt();
        }
    }
}
