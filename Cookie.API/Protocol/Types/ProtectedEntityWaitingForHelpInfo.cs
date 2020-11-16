using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ProtectedEntityWaitingForHelpInfo : NetworkType
    {
        public const ushort ProtocolId = 186;

        public override ushort TypeID => ProtocolId;

        public int TimeLeftBeforeFight { get; set; }
        public int WaitTimeForPlacement { get; set; }
        public sbyte NbPositionForDefensors { get; set; }
        public ProtectedEntityWaitingForHelpInfo() { }

        public ProtectedEntityWaitingForHelpInfo( int TimeLeftBeforeFight, int WaitTimeForPlacement, sbyte NbPositionForDefensors ){
            this.TimeLeftBeforeFight = TimeLeftBeforeFight;
            this.WaitTimeForPlacement = WaitTimeForPlacement;
            this.NbPositionForDefensors = NbPositionForDefensors;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(TimeLeftBeforeFight);
            writer.WriteInt(WaitTimeForPlacement);
            writer.WriteSByte(NbPositionForDefensors);
        }

        public override void Deserialize(IDataReader reader)
        {
            TimeLeftBeforeFight = reader.ReadInt();
            WaitTimeForPlacement = reader.ReadInt();
            NbPositionForDefensors = reader.ReadSByte();
        }
    }
}
