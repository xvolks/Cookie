using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ProtocolRequired : NetworkMessage
    {
        public const uint ProtocolId = 1;
        public override uint MessageID { get { return ProtocolId; } }

        public int RequiredVersion = 0;
        public int CurrentVersion = 0;

        public ProtocolRequired()
        {
        }

        public ProtocolRequired(
            int requiredVersion,
            int currentVersion
        )
        {
            RequiredVersion = requiredVersion;
            CurrentVersion = currentVersion;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(RequiredVersion);
            writer.WriteInt(CurrentVersion);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RequiredVersion = reader.ReadInt();
            CurrentVersion = reader.ReadInt();
        }
    }
}