using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
    {
        public new const uint ProtocolId = 6116;
        public override uint MessageID { get { return ProtocolId; } }

        public short WeaponGenericId = 0;

        public GameActionFightCloseCombatMessage(): base()
        {
        }

        public GameActionFightCloseCombatMessage(
            short actionId,
            double sourceId,
            bool silentCast,
            bool verboseCast,
            double targetId,
            short destinationCellId,
            byte critical,
            short weaponGenericId
        ): base(
            actionId,
            sourceId,
            silentCast,
            verboseCast,
            targetId,
            destinationCellId,
            critical
        )
        {
            WeaponGenericId = weaponGenericId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(WeaponGenericId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            WeaponGenericId = reader.ReadVarShort();
        }
    }
}