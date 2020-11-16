using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public new const ushort ProtocolId = 159;

        public override ushort TypeID => ProtocolId;

        public HumanInformations HumanoidInfo { get; set; }
        public int AccountId { get; set; }
        public GameRolePlayHumanoidInformations() { }

        public GameRolePlayHumanoidInformations( HumanInformations HumanoidInfo, int AccountId ){
            this.HumanoidInfo = HumanoidInfo;
            this.AccountId = AccountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            HumanoidInfo.Serialize(writer);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HumanoidInfo = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            HumanoidInfo.Deserialize(reader);
            AccountId = reader.ReadInt();
        }
    }
}
