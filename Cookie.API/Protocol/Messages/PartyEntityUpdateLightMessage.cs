using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyEntityUpdateLightMessage : PartyUpdateLightMessage
    {
        public new const ushort ProtocolId = 6781;

        public override ushort MessageID => ProtocolId;

        public sbyte IndexId { get; set; }
        public PartyEntityUpdateLightMessage() { }

        public PartyEntityUpdateLightMessage( sbyte IndexId ){
            this.IndexId = IndexId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(IndexId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IndexId = reader.ReadSByte();
        }
    }
}
