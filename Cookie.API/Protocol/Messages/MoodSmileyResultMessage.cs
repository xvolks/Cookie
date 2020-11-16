using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MoodSmileyResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6196;

        public override ushort MessageID => ProtocolId;

        public sbyte ResultCode { get; set; }
        public ushort SmileyId { get; set; }
        public MoodSmileyResultMessage() { }

        public MoodSmileyResultMessage( sbyte ResultCode, ushort SmileyId ){
            this.ResultCode = ResultCode;
            this.SmileyId = SmileyId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ResultCode);
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ResultCode = reader.ReadSByte();
            SmileyId = reader.ReadVarUhShort();
        }
    }
}
