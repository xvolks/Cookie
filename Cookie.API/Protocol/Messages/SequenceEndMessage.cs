using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SequenceEndMessage : NetworkMessage
    {
        public const ushort ProtocolId = 956;

        public override ushort MessageID => ProtocolId;

        public ushort ActionId { get; set; }
        public double AuthorId { get; set; }
        public sbyte SequenceType { get; set; }
        public SequenceEndMessage() { }

        public SequenceEndMessage( ushort ActionId, double AuthorId, sbyte SequenceType ){
            this.ActionId = ActionId;
            this.AuthorId = AuthorId;
            this.SequenceType = SequenceType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
            writer.WriteDouble(AuthorId);
            writer.WriteSByte(SequenceType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
            AuthorId = reader.ReadDouble();
            SequenceType = reader.ReadSByte();
        }
    }
}
