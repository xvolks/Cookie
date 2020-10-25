using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ContactLookMessage : NetworkMessage
    {
        public const uint ProtocolId = 5934;
        public override uint MessageID { get { return ProtocolId; } }

        public int RequestId = 0;
        public string PlayerName;
        public long PlayerId = 0;
        public EntityLook Look;

        public ContactLookMessage()
        {
        }

        public ContactLookMessage(
            int requestId,
            string playerName,
            long playerId,
            EntityLook look
        )
        {
            RequestId = requestId;
            PlayerName = playerName;
            PlayerId = playerId;
            Look = look;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(RequestId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarLong(PlayerId);
            Look.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequestId = reader.ReadVarInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadVarLong();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}