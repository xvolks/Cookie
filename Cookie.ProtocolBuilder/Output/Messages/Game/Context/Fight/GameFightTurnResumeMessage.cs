namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightTurnResumeMessage : GameFightTurnStartMessage
    {
        public new const ushort ProtocolId = 6307;
        public override ushort MessageID => ProtocolId;
        public uint RemainingTime { get; set; }

        public GameFightTurnResumeMessage(uint remainingTime)
        {
            RemainingTime = remainingTime;
        }

        public GameFightTurnResumeMessage() { }

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
