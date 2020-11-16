using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StatsUpgradeResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5609;

        public override ushort MessageID => ProtocolId;

        public sbyte Result { get; set; }
        public ushort NbCharacBoost { get; set; }
        public StatsUpgradeResultMessage() { }

        public StatsUpgradeResultMessage( sbyte Result, ushort NbCharacBoost ){
            this.Result = Result;
            this.NbCharacBoost = NbCharacBoost;
        }

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
