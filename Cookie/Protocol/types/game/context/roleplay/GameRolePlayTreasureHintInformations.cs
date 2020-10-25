using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
    {
        public new const short ProtocolId = 471;
        public override short TypeId { get { return ProtocolId; } }

        public short NpcId = 0;

        public GameRolePlayTreasureHintInformations(): base()
        {
        }

        public GameRolePlayTreasureHintInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            short npcId
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            NpcId = npcId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(NpcId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarShort();
        }
    }
}