using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ProtocolRequired : NetworkMessage
    {
        public const ushort ProtocolId = 1;

        public override ushort MessageID => ProtocolId;

        public int RequiredVersion { get; set; }
        public int CurrentVersion { get; set; }
        public ProtocolRequired() { }

        public ProtocolRequired( int RequiredVersion, int CurrentVersion ){
            this.RequiredVersion = RequiredVersion;
            this.CurrentVersion = CurrentVersion;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequiredVersion);
            writer.WriteInt(CurrentVersion);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequiredVersion = reader.ReadInt();
            CurrentVersion = reader.ReadInt();
        }
    }
}
