using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightTurnResumeMessage : GameFightTurnStartMessage
    {
        public new const ushort ProtocolId = 6307;

        public override ushort MessageID => ProtocolId;

        public uint RemainingTime { get; set; }
        public GameFightTurnResumeMessage() { }

        public GameFightTurnResumeMessage( uint RemainingTime ){
            this.RemainingTime = RemainingTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(RemainingTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            RemainingTime = reader.ReadVarUhInt();
        }
    }
}
