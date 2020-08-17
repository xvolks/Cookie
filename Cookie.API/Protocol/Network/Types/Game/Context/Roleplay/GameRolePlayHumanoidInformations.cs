using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public new const ushort ProtocolId = 159;

        public GameRolePlayHumanoidInformations(HumanInformations humanoidInfo, int accountId)
        {
            HumanoidInfo = humanoidInfo;
            AccountId = accountId;
        }

        public GameRolePlayHumanoidInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public HumanInformations HumanoidInfo { get; set; }
        public int AccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(HumanoidInfo.TypeID);
            HumanoidInfo.Serialize(writer);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HumanoidInfo = ProtocolTypeManager.GetInstance<HumanInformations>(reader.ReadUShort());
            HumanoidInfo.Deserialize(reader);
            AccountId = reader.ReadInt();
        }
    }
}