using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EnterHavenBagRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6636;

        public override ushort MessageID => ProtocolId;

        public ulong HavenBagOwner { get; set; }
        public EnterHavenBagRequestMessage() { }

        public EnterHavenBagRequestMessage( ulong HavenBagOwner ){
            this.HavenBagOwner = HavenBagOwner;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(HavenBagOwner);
        }

        public override void Deserialize(IDataReader reader)
        {
            HavenBagOwner = reader.ReadVarUhLong();
        }
    }
}
