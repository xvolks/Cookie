using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public new const ushort ProtocolId = 6461;

        public override ushort MessageID => ProtocolId;

        public bool Preview { get; set; }
        public MimicryObjectErrorMessage() { }

        public MimicryObjectErrorMessage( bool Preview ){
            this.Preview = Preview;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Preview);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Preview = reader.ReadBoolean();
        }
    }
}
