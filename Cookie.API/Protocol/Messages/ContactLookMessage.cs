using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ContactLookMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5934;

        public override ushort MessageID => ProtocolId;

        public uint RequestId { get; set; }
        public string PlayerName { get; set; }
        public ulong PlayerId { get; set; }
        public EntityLook Look { get; set; }
        public ContactLookMessage() { }

        public ContactLookMessage( uint RequestId, string PlayerName, ulong PlayerId, EntityLook Look ){
            this.RequestId = RequestId;
            this.PlayerName = PlayerName;
            this.PlayerId = PlayerId;
            this.Look = Look;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(RequestId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarUhLong(PlayerId);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadVarUhInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadVarUhLong();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }
    }
}
