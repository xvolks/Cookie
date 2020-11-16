using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage
    {
        public new const ushort ProtocolId = 6463;

        public override ushort MessageID => ProtocolId;

        public uint Uid { get; set; }
        public ClientUIOpenedByObjectMessage() { }

        public ClientUIOpenedByObjectMessage( uint Uid ){
            this.Uid = Uid;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Uid);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Uid = reader.ReadVarUhInt();
        }
    }
}
