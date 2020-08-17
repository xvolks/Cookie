using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 471;

        public GameRolePlayTreasureHintInformations(ushort npcId)
        {
            NpcId = npcId;
        }

        public GameRolePlayTreasureHintInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort NpcId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NpcId = reader.ReadVarUhShort();
        }
    }
}