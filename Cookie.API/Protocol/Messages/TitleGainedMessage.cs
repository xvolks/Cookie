using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TitleGainedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6364;

        public override ushort MessageID => ProtocolId;

        public ushort TitleId { get; set; }
        public TitleGainedMessage() { }

        public TitleGainedMessage( ushort TitleId ){
            this.TitleId = TitleId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(TitleId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TitleId = reader.ReadVarUhShort();
        }
    }
}
