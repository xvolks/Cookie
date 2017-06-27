using System;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Handshake
{
    public class ProtocolRequired : NetworkMessage
    {
        public const uint ProtocolId = 1;

        public ProtocolRequired()
        {
        }

        public ProtocolRequired(int requiredVersion, int currentVersion)
        {
            RequiredVersion = requiredVersion;
            CurrentVersion = currentVersion;
        }

        public override uint MessageID => ProtocolId;

        public int RequiredVersion { get; set; }
        public int CurrentVersion { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(RequiredVersion);
            writer.WriteInt(CurrentVersion);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequiredVersion = reader.ReadInt();
            if (RequiredVersion < 0)
                throw new Exception("Forbidden value on RequiredVersion = " + RequiredVersion +
                                    ", it doesn't respect the following condition : requiredVersion < 0");
            CurrentVersion = reader.ReadInt();
            if (CurrentVersion < 0)
                throw new Exception("Forbidden value on CurrentVersion = " + CurrentVersion +
                                    ", it doesn't respect the following condition : currentVersion < 0");
        }
    }
}