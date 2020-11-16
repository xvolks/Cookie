using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightTurnStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 714;

        public override ushort MessageID => ProtocolId;

        public double Id { get; set; }
        public uint WaitTime { get; set; }
        public GameFightTurnStartMessage() { }

        public GameFightTurnStartMessage( double Id, uint WaitTime ){
            this.Id = Id;
            this.WaitTime = WaitTime;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Id);
            writer.WriteVarUhInt(WaitTime);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadDouble();
            WaitTime = reader.ReadVarUhInt();
        }
    }
}
