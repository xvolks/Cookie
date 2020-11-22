using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountEmoteIconUsedOkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5978;

        public override ushort MessageID => ProtocolId;

        public int MountId { get; set; }
        public sbyte ReactionType { get; set; }
        public MountEmoteIconUsedOkMessage() { }

        public MountEmoteIconUsedOkMessage( int MountId, sbyte ReactionType ){
            this.MountId = MountId;
            this.ReactionType = ReactionType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteSByte(ReactionType);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
            ReactionType = reader.ReadSByte();
        }
    }
}
