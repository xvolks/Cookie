using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MoodSmileyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6192;

        public override ushort MessageID => ProtocolId;

        public ushort SmileyId { get; set; }
        public MoodSmileyRequestMessage() { }

        public MoodSmileyRequestMessage( ushort SmileyId ){
            this.SmileyId = SmileyId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SmileyId = reader.ReadVarUhShort();
        }
    }
}
