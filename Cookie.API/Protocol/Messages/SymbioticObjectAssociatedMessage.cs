using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SymbioticObjectAssociatedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6527;

        public override ushort MessageID => ProtocolId;

        public uint HostUID { get; set; }
        public SymbioticObjectAssociatedMessage() { }

        public SymbioticObjectAssociatedMessage( uint HostUID ){
            this.HostUID = HostUID;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HostUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostUID = reader.ReadVarUhInt();
        }
    }
}
