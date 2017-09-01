using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Stats
{
    public class StatsUpgradeResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5609;

        public StatsUpgradeResultMessage(sbyte result, ushort nbCharacBoost)
        {
            Result = result;
            NbCharacBoost = nbCharacBoost;
        }

        public StatsUpgradeResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte Result { get; set; }
        public ushort NbCharacBoost { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Result);
            writer.WriteVarUhShort(NbCharacBoost);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadSByte();
            NbCharacBoost = reader.ReadVarUhShort();
        }
    }
}