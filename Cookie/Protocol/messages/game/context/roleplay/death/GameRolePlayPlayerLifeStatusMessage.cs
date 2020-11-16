using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayPlayerLifeStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 5996;
        public override uint MessageID { get { return ProtocolId; } }

        public byte State = 0;
        public double PhenixMapId = 0;

        public GameRolePlayPlayerLifeStatusMessage()
        {
        }

        public GameRolePlayPlayerLifeStatusMessage(
            byte state,
            double phenixMapId
        )
        {
            State = state;
            PhenixMapId = phenixMapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(State);
            writer.WriteDouble(PhenixMapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            State = reader.ReadByte();
            PhenixMapId = reader.ReadDouble();
        }
    }
}