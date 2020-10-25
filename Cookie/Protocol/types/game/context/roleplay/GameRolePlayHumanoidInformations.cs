using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public new const short ProtocolId = 159;
        public override short TypeId { get { return ProtocolId; } }

        public HumanInformations HumanoidInfo;
        public int AccountId = 0;

        public GameRolePlayHumanoidInformations(): base()
        {
        }

        public GameRolePlayHumanoidInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            string name,
            HumanInformations humanoidInfo,
            int accountId
        ): base(
            contextualId,
            look,
            disposition,
            name
        )
        {
            HumanoidInfo = humanoidInfo;
            AccountId = accountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(HumanoidInfo.TypeId);
            HumanoidInfo.Serialize(writer);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var humanoidInfoTypeId = reader.ReadShort();
            HumanoidInfo = new HumanInformations();
            HumanoidInfo.Deserialize(reader);
            AccountId = reader.ReadInt();
        }
    }
}