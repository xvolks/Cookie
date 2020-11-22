using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayPlayerLifeStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5996;

        public override ushort MessageID => ProtocolId;

        public sbyte State { get; set; }
        public double PhenixMapId { get; set; }
        public GameRolePlayPlayerLifeStatusMessage() { }

        public GameRolePlayPlayerLifeStatusMessage( sbyte State, double PhenixMapId ){
            this.State = State;
            this.PhenixMapId = PhenixMapId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(State);
            writer.WriteDouble(PhenixMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            State = reader.ReadSByte();
            PhenixMapId = reader.ReadDouble();
        }
    }
}
