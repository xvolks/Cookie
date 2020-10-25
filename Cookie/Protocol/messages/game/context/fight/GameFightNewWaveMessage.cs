using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightNewWaveMessage : NetworkMessage
    {
        public const uint ProtocolId = 6490;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Id_ = 0;
        public byte TeamId = 2;
        public short NbTurnBeforeNextWave = 0;

        public GameFightNewWaveMessage()
        {
        }

        public GameFightNewWaveMessage(
            byte id_,
            byte teamId,
            short nbTurnBeforeNextWave
        )
        {
            Id_ = id_;
            TeamId = teamId;
            NbTurnBeforeNextWave = nbTurnBeforeNextWave;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Id_);
            writer.WriteByte(TeamId);
            writer.WriteShort(NbTurnBeforeNextWave);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadByte();
            TeamId = reader.ReadByte();
            NbTurnBeforeNextWave = reader.ReadShort();
        }
    }
}