using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountRenameRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5987;

        public override ushort MessageID => ProtocolId;

        public string Name { get; set; }
        public int MountId { get; set; }
        public MountRenameRequestMessage() { }

        public MountRenameRequestMessage( string Name, int MountId ){
            this.Name = Name;
            this.MountId = MountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            MountId = reader.ReadVarInt();
        }
    }
}
