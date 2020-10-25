using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightOptionStateUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5927;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public byte TeamId = 2;
        public byte Option = 3;
        public bool State = false;

        public GameFightOptionStateUpdateMessage()
        {
        }

        public GameFightOptionStateUpdateMessage(
            short fightId,
            byte teamId,
            byte option,
            bool state
        )
        {
            FightId = fightId;
            TeamId = teamId;
            Option = option;
            State = state;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteByte(TeamId);
            writer.WriteByte(Option);
            writer.WriteBoolean(State);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            TeamId = reader.ReadByte();
            Option = reader.ReadByte();
            State = reader.ReadBoolean();
        }
    }
}