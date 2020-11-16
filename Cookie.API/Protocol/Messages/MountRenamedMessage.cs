using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountRenamedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5983;

        public override ushort MessageID => ProtocolId;

        public int MountId { get; set; }
        public string Name { get; set; }
        public MountRenamedMessage() { }

        public MountRenamedMessage( int MountId, string Name ){
            this.MountId = MountId;
            this.Name = Name;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
            Name = reader.ReadUTF();
        }
    }
}
