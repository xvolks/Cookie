using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    public class EmotePlayMessage : EmotePlayAbstractMessage
    {
        public new const ushort ProtocolId = 5683;

        public EmotePlayMessage(double actorId, int accountId)
        {
            ActorId = actorId;
            AccountId = accountId;
        }

        public EmotePlayMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double ActorId { get; set; }
        public int AccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(ActorId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ActorId = reader.ReadDouble();
            AccountId = reader.ReadInt();
        }
    }
}