using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightNewWaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6490;

        public override ushort MessageID => ProtocolId;

        public sbyte Id { get; set; }
        public sbyte TeamId { get; set; }
        public short NbTurnBeforeNextWave { get; set; }
        public GameFightNewWaveMessage() { }

        public GameFightNewWaveMessage( sbyte Id, sbyte TeamId, short NbTurnBeforeNextWave ){
            this.Id = Id;
            this.TeamId = TeamId;
            this.NbTurnBeforeNextWave = NbTurnBeforeNextWave;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Id);
            writer.WriteSByte(TeamId);
            writer.WriteShort(NbTurnBeforeNextWave);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadSByte();
            TeamId = reader.ReadSByte();
            NbTurnBeforeNextWave = reader.ReadShort();
        }
    }
}
