using Cookie.IO;
using Cookie.Protocol.Network.Types.Version;
using System;

namespace Cookie.Protocol.Network.Messages.Connection
{
    public class IdentificationMessage : NetworkMessage
    {
        public const uint ProtocolId = 4;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Autoconnect { get; set; }
        public bool UseCertificate { get; set; }
        public bool UseLoginToken { get; set; }
        public VersionExtended Version { get; set; }
        public string Lang { get; set; }
        public byte[] Credentials { get; set; }
        public short ServerId { get; set; }
        public long SessionOptionalSalt { get; set; }
        public ushort[] FailedAttempts { get; set; }

        public IdentificationMessage() { }

        public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, VersionExtended version, string lang, byte[] credentials, short serverId, long sessionOptionalSalt, ushort[] failedAttempts)
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

        public override void Serialize(ICustomDataOutput writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, Autoconnect);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, UseCertificate);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, UseLoginToken);
            writer.WriteByte(flag1);
            Version.Serialize(writer);
            writer.WriteUTF(Lang);
            writer.WriteVarInt(Credentials.Length);
            foreach (var entry in Credentials)
            {
                writer.WriteByte(entry);
            }
            writer.WriteShort(ServerId);
            writer.WriteVarLong(SessionOptionalSalt);
            writer.WriteShort((short)FailedAttempts.Length);
            foreach (var entry in FailedAttempts)
            {
                writer.WriteVarShort((short)entry);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var flag1 = reader.ReadByte();
            Autoconnect = BooleanByteWrapper.GetFlag(flag1, 0);
            UseCertificate = BooleanByteWrapper.GetFlag(flag1, 1);
            UseLoginToken = BooleanByteWrapper.GetFlag(flag1, 2);
            Version = new VersionExtended();
            Version.Deserialize(reader);
            Lang = reader.ReadUTF();
            var limit = reader.ReadVarInt();
            Credentials = new byte[limit];
            for (var i = 0; i < limit; i++)
            {
                Credentials[i] = reader.ReadByte();
            }
            ServerId = reader.ReadShort();
            SessionOptionalSalt = reader.ReadVarLong();
            if (SessionOptionalSalt < -9007199254740990 || SessionOptionalSalt > 9007199254740990)
                throw new Exception("Forbidden value on SessionOptionalSalt = " + SessionOptionalSalt + ", it doesn't respect the following condition : sessionOptionalSalt < -9007199254740990 || sessionOptionalSalt > 9007199254740990");
            limit = reader.ReadUShort();
            FailedAttempts = new ushort[limit];
            for (var i = 0; i < limit; i++)
            {
                FailedAttempts[i] = reader.ReadVarUhShort();
            }
        }

    }
}
