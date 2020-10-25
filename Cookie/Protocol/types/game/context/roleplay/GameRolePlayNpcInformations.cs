using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayNpcInformations : GameRolePlayActorInformations
    {
        public new const short ProtocolId = 156;
        public override short TypeId { get { return ProtocolId; } }

        public short NpcId = 0;
        public bool Sex = false;
        public short SpecialArtworkId = 0;

        public GameRolePlayNpcInformations(): base()
        {
        }

        public GameRolePlayNpcInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            short npcId,
            bool sex,
            short specialArtworkId
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            NpcId = npcId;
            Sex = sex;
            SpecialArtworkId = specialArtworkId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(NpcId);
            writer.WriteBoolean(Sex);
            writer.WriteVarShort(SpecialArtworkId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarShort();
            Sex = reader.ReadBoolean();
            SpecialArtworkId = reader.ReadVarShort();
        }
    }
}