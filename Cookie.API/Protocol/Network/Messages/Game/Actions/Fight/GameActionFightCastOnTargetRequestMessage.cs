using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightCastOnTargetRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6330;

        public GameActionFightCastOnTargetRequestMessage(ushort spellId, double targetId)
        {
            SpellId = spellId;
            TargetId = targetId;
        }

        public GameActionFightCastOnTargetRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SpellId { get; set; }
        public double TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
            TargetId = reader.ReadDouble();
        }
    }
}