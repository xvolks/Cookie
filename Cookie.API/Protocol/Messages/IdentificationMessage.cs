using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdentificationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 4;

        public override ushort MessageID => ProtocolId;

        public bool Autoconnect { get; set; }
        public bool UseCertificate { get; set; }
        public bool UseLoginToken { get; set; }
        public VersionExtended Version { get; set; }
        public string Lang { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientKey { get; set; }
        public short ServerId { get; set; }
        public long SessionOptionalSalt { get; set; }
        public List<short> FailedAttempts { get; set; }
        public IdentificationMessage() { }

        public IdentificationMessage( bool Autoconnect, bool UseCertificate, bool UseLoginToken, VersionExtended Version, string Lang, string Username, string Password, string ClientKey, short ServerId, long SessionOptionalSalt, List<short> FailedAttempts ){
            this.Autoconnect = Autoconnect;
            this.UseCertificate = UseCertificate;
            this.UseLoginToken = UseLoginToken;
            this.Version = Version;
            this.Lang = Lang;
            this.Username = Username;
            this.Password = Password;
            this.ClientKey = ClientKey;
            this.ServerId = ServerId;
            this.SessionOptionalSalt = SessionOptionalSalt;
            this.FailedAttempts = FailedAttempts;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Autoconnect);
			flag = BooleanByteWrapper.SetFlag(1, flag, UseCertificate);
			flag = BooleanByteWrapper.SetFlag(2, flag, UseLoginToken);
			writer.WriteByte(flag);
            Version.Serialize(writer);
            writer.WriteUTF(Lang);
            writer.WriteUTF(Username);
            writer.WriteUTF(Password);
            writer.WriteUTF(ClientKey);
            writer.WriteShort(ServerId);
            writer.WriteVarLong(SessionOptionalSalt);
			writer.WriteShort((short)FailedAttempts.Count);
			foreach (var x in FailedAttempts)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Autoconnect = BooleanByteWrapper.GetFlag(flag, 0);;
			UseCertificate = BooleanByteWrapper.GetFlag(flag, 1);;
			UseLoginToken = BooleanByteWrapper.GetFlag(flag, 2);;
            Version = new VersionExtended();
            Version.Deserialize(reader);
            Lang = reader.ReadUTF();
            Username = reader.ReadUTF();
            Password = reader.ReadUTF();
            ClientKey = reader.ReadUTF();
            ServerId = reader.ReadShort();
            SessionOptionalSalt = reader.ReadVarLong();
            var FailedAttemptsCount = reader.ReadShort();
            FailedAttempts = new List<short>();
            for (var i = 0; i < FailedAttemptsCount; i++)
            {
                FailedAttempts.Add(reader.ReadVarShort());
            }
        }
    }
}
