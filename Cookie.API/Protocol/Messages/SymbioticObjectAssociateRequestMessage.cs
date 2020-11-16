using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SymbioticObjectAssociateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6522;

        public override ushort MessageID => ProtocolId;

        public uint SymbioteUID { get; set; }
        public byte SymbiotePos { get; set; }
        public uint HostUID { get; set; }
        public byte HostPos { get; set; }
        public SymbioticObjectAssociateRequestMessage() { }

        public SymbioticObjectAssociateRequestMessage( uint SymbioteUID, byte SymbiotePos, uint HostUID, byte HostPos ){
            this.SymbioteUID = SymbioteUID;
            this.SymbiotePos = SymbiotePos;
            this.HostUID = HostUID;
            this.HostPos = HostPos;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SymbioteUID);
            writer.WriteByte(SymbiotePos);
            writer.WriteVarUhInt(HostUID);
            writer.WriteByte(HostPos);
        }

        public override void Deserialize(IDataReader reader)
        {
            SymbioteUID = reader.ReadVarUhInt();
            SymbiotePos = reader.ReadByte();
            HostUID = reader.ReadVarUhInt();
            HostPos = reader.ReadByte();
        }
    }
}
