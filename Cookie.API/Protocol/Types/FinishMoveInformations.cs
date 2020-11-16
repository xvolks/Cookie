using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FinishMoveInformations : NetworkType
    {
        public const ushort ProtocolId = 506;

        public override ushort TypeID => ProtocolId;

        public int FinishMoveId { get; set; }
        public bool FinishMoveState { get; set; }
        public FinishMoveInformations() { }

        public FinishMoveInformations( int FinishMoveId, bool FinishMoveState ){
            this.FinishMoveId = FinishMoveId;
            this.FinishMoveState = FinishMoveState;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FinishMoveId);
            writer.WriteBoolean(FinishMoveState);
        }

        public override void Deserialize(IDataReader reader)
        {
            FinishMoveId = reader.ReadInt();
            FinishMoveState = reader.ReadBoolean();
        }
    }
}
