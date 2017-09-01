using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Spell
{
    public class SpellVariantActivationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6705;

        public SpellVariantActivationMessage(bool result, ushort activatedSpellId, ushort deactivatedSpellId)
        {
            Result = result;
            ActivatedSpellId = activatedSpellId;
            DeactivatedSpellId = deactivatedSpellId;
        }

        public SpellVariantActivationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Result { get; set; }
        public ushort ActivatedSpellId { get; set; }
        public ushort DeactivatedSpellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Result);
            writer.WriteVarUhShort(ActivatedSpellId);
            writer.WriteVarUhShort(DeactivatedSpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadBoolean();
            ActivatedSpellId = reader.ReadVarUhShort();
            DeactivatedSpellId = reader.ReadVarUhShort();
        }
    }
}