using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Fight
{
    public class ProtectedEntityWaitingForHelpInfo : NetworkType
    {
        public const ushort ProtocolId = 186;

        public ProtectedEntityWaitingForHelpInfo(int timeLeftBeforeFight, int waitTimeForPlacement,
            byte nbPositionForDefensors)
        {
            TimeLeftBeforeFight = timeLeftBeforeFight;
            WaitTimeForPlacement = waitTimeForPlacement;
            NbPositionForDefensors = nbPositionForDefensors;
        }

        public ProtectedEntityWaitingForHelpInfo()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int TimeLeftBeforeFight { get; set; }
        public int WaitTimeForPlacement { get; set; }
        public byte NbPositionForDefensors { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(TimeLeftBeforeFight);
            writer.WriteInt(WaitTimeForPlacement);
            writer.WriteByte(NbPositionForDefensors);
        }

        public override void Deserialize(IDataReader reader)
        {
            TimeLeftBeforeFight = reader.ReadInt();
            WaitTimeForPlacement = reader.ReadInt();
            NbPositionForDefensors = reader.ReadByte();
        }
    }
}