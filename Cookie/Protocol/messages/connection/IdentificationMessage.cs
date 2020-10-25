using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class IdentificationMessage : NetworkMessage
    {
        public const uint ProtocolId = 4;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Autoconnect = false;
        public bool UseCertificate = false;
        public bool UseLoginToken = false;
        public VersionExtended Version;
        public string Lang;
        public string AccountName;
        public string Password;
        public short ServerId = 0;
        public long SessionOptionalSalt = 0;
        public ICollection<short> FailedAttempts;

        public IdentificationMessage()
        {
        }

        public IdentificationMessage(
            bool autoconnect,
            bool useCertificate,
            bool useLoginToken,
            VersionExtended version,
            string lang,
            string accountName,
            string password,
            short serverId,
            long sessionOptionalSalt,
            ICollection<short> failedAttempts
        )
        {
            Autoconnect = autoconnect;
            UseCertificate = useCertificate;
            UseLoginToken = useLoginToken;
            Version = version;
            Lang = lang;
            AccountName = accountName;
            Password = password;
            ServerId = serverId;
            SessionOptionalSalt = sessionOptionalSalt;
            FailedAttempts = failedAttempts;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Autoconnect);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, UseCertificate);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, UseLoginToken);
            writer.WriteByte(box0);
            Version.Serialize(writer);
            writer.WriteUTF(Lang);
            writer.WriteUTF(AccountName);
            writer.WriteUTF(Password);
            writer.WriteUTF("y3JJiZ0geixj3GDmm2#01");
            writer.WriteBytes(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 });
            //writer.WriteVarInt((int)Credentials.Count());
            //foreach (var current in Credentials)
            //{
            //    writer.WriteByte(current);
            //}
            //writer.WriteShort(ServerId);
            //writer.WriteVarLong(SessionOptionalSalt);
            //writer.WriteShort((short)FailedAttempts.Count());
            //foreach (var current in FailedAttempts)
            //{
            //    writer.WriteVarShort(current);
            //}
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Autoconnect = BooleanByteWrapper.GetFlag(box0, 1);
            UseCertificate = BooleanByteWrapper.GetFlag(box0, 2);
            UseLoginToken = BooleanByteWrapper.GetFlag(box0, 3);
            Version = new VersionExtended();
            Version.Deserialize(reader);
            Lang = reader.ReadUTF();
            //var countCredentials = reader.ReadVarInt();
            //Credentials = new List<byte>();
            //for (int i = 0; i < countCredentials; i++)
            //{
            //    Credentials.Add(reader.ReadByte());
            //}
            ServerId = reader.ReadShort();
            SessionOptionalSalt = reader.ReadVarLong();
            var countFailedAttempts = reader.ReadShort();
            FailedAttempts = new List<short>();
            for (short i = 0; i < countFailedAttempts; i++)
            {
                FailedAttempts.Add(reader.ReadVarShort());
            }
        }
    }
}