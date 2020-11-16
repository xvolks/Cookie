using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MimicryObjectEraseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6457;

        public override ushort MessageID => ProtocolId;

        public uint HostUID { get; set; }
        public byte HostPos { get; set; }
        public MimicryObjectEraseRequestMessage() { }

        public MimicryObjectEraseRequestMessage( uint HostUID, byte HostPos ){
            this.HostUID = HostUID;
            this.HostPos = HostPos;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HostUID);
            writer.WriteByte(HostPos);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostUID = reader.ReadVarUhInt();
            HostPos = reader.ReadByte();
        }
    }
}
