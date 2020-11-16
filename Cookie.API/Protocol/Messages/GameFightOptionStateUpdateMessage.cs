using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightOptionStateUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5927;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public sbyte TeamId { get; set; }
        public sbyte Option { get; set; }
        public bool State { get; set; }
        public GameFightOptionStateUpdateMessage() { }

        public GameFightOptionStateUpdateMessage( ushort FightId, sbyte TeamId, sbyte Option, bool State ){
            this.FightId = FightId;
            this.TeamId = TeamId;
            this.Option = Option;
            this.State = State;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
            writer.WriteSByte(TeamId);
            writer.WriteSByte(Option);
            writer.WriteBoolean(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            TeamId = reader.ReadSByte();
            Option = reader.ReadSByte();
            State = reader.ReadBoolean();
        }
    }
}
