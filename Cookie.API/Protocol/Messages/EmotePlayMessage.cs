using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EmotePlayMessage : EmotePlayAbstractMessage
    {
        public new const ushort ProtocolId = 5683;

        public override ushort MessageID => ProtocolId;

        public double ActorId { get; set; }
        public int AccountId { get; set; }
        public EmotePlayMessage() { }

        public EmotePlayMessage( double ActorId, int AccountId ){
            this.ActorId = ActorId;
            this.AccountId = AccountId;
        }

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
