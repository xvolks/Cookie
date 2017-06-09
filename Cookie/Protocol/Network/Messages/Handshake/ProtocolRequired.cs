using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages.Handshake
{
    public class ProtocolRequired : NetworkMessage
    {
        public const uint ProtocolId = 1;
        public override uint MessageID { get { return ProtocolId; } }

        public uint RequiredVersion { get; set; }
        public uint CurrentVersion { get; set; }

        public ProtocolRequired() { }

        public ProtocolRequired(uint requiredVersion, uint currentVersion)
        {
            this.RequiredVersion = requiredVersion;
            this.CurrentVersion = currentVersion;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUInt(RequiredVersion);
            writer.WriteUInt(CurrentVersion);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequiredVersion = reader.ReadUInt();
            if (RequiredVersion < 0)
                throw new Exception("Forbidden value on RequiredVersion = " + RequiredVersion + ", it doesn't respect the following condition : requiredVersion < 0");
            CurrentVersion = reader.ReadUInt();
            if (CurrentVersion < 0)
                throw new Exception("Forbidden value on CurrentVersion = " + CurrentVersion + ", it doesn't respect the following condition : currentVersion < 0");
        }

    }
}
