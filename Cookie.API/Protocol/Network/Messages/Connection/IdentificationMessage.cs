using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Version;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class IdentificationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 4;

        public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, VersionExtended version,
            string lang, List<sbyte> credentials, short serverId, long sessionOptionalSalt, List<ushort> failedAttempts)
        {
            Autoconnect = autoconnect;
            UseCertificate = useCertificate;
            UseLoginToken = useLoginToken;
            Version = version;
            Lang = lang;
            Credentials = credentials;
            ServerId = serverId;
            SessionOptionalSalt = sessionOptionalSalt;
            FailedAttempts = failedAttempts;
        }

        public IdentificationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Autoconnect { get; set; }
        public bool UseCertificate { get; set; }
        public bool UseLoginToken { get; set; }
        public VersionExtended Version { get; set; }
        public string Lang { get; set; }
        public List<sbyte> Credentials { get; set; }
        public short ServerId { get; set; }
        public long SessionOptionalSalt { get; set; }
        public List<ushort> FailedAttempts { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Autoconnect);
            flag = BooleanByteWrapper.SetFlag(1, flag, UseCertificate);
            flag = BooleanByteWrapper.SetFlag(2, flag, UseLoginToken);
            writer.WriteByte(flag);
            Version.Serialize(writer);
            writer.WriteUTF(Lang);
            writer.WriteVarInt(Credentials.Count);
            for (var credentialsIndex = 0; credentialsIndex < Credentials.Count; credentialsIndex++)
                writer.WriteSByte(Credentials[credentialsIndex]);
            writer.WriteShort(ServerId);
            writer.WriteVarLong(SessionOptionalSalt);
            writer.WriteShort((short) FailedAttempts.Count);
            for (var failedAttemptsIndex = 0; failedAttemptsIndex < FailedAttempts.Count; failedAttemptsIndex++)
                writer.WriteVarUhShort(FailedAttempts[failedAttemptsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Autoconnect = BooleanByteWrapper.GetFlag(flag, 0);
            UseCertificate = BooleanByteWrapper.GetFlag(flag, 1);
            UseLoginToken = BooleanByteWrapper.GetFlag(flag, 2);
            Version = new VersionExtended();
            Version.Deserialize(reader);
            Lang = reader.ReadUTF();
            var credentialsCount = reader.ReadVarInt();
            Credentials = new List<sbyte>();
            for (var credentialsIndex = 0; credentialsIndex < credentialsCount; credentialsIndex++)
                Credentials.Add(reader.ReadSByte());
            ServerId = reader.ReadShort();
            SessionOptionalSalt = reader.ReadVarLong();
            var failedAttemptsCount = reader.ReadUShort();
            FailedAttempts = new List<ushort>();
            for (var failedAttemptsIndex = 0; failedAttemptsIndex < failedAttemptsCount; failedAttemptsIndex++)
                FailedAttempts.Add(reader.ReadVarUhShort());
        }
    }
}