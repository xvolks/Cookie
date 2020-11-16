using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StatsUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5610;

        public override ushort MessageID => ProtocolId;

        public bool UseAdditionnal { get; set; }
        public sbyte StatId { get; set; }
        public ushort BoostPoint { get; set; }
        public StatsUpgradeRequestMessage() { }

        public StatsUpgradeRequestMessage( bool UseAdditionnal, sbyte StatId, ushort BoostPoint ){
            this.UseAdditionnal = UseAdditionnal;
            this.StatId = StatId;
            this.BoostPoint = BoostPoint;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(UseAdditionnal);
            writer.WriteSByte(StatId);
            writer.WriteVarUhShort(BoostPoint);
        }

        public override void Deserialize(IDataReader reader)
        {
            UseAdditionnal = reader.ReadBoolean();
            StatId = reader.ReadSByte();
            BoostPoint = reader.ReadVarUhShort();
        }
    }
}
