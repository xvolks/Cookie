using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyNameSetErrorMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6501;

        public override ushort MessageID => ProtocolId;

        public sbyte Result { get; set; }
        public PartyNameSetErrorMessage() { }

        public PartyNameSetErrorMessage( sbyte Result ){
            this.Result = Result;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Result = reader.ReadSByte();
        }
    }
}
