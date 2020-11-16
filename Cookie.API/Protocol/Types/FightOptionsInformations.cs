using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightOptionsInformations : NetworkType
    {
        public const ushort ProtocolId = 20;

        public override ushort TypeID => ProtocolId;

        public bool IsSecret { get; set; }
        public bool IsRestrictedToPartyOnly { get; set; }
        public bool IsClosed { get; set; }
        public bool IsAskingForHelp { get; set; }
        public FightOptionsInformations() { }

        public FightOptionsInformations( bool IsSecret, bool IsRestrictedToPartyOnly, bool IsClosed, bool IsAskingForHelp ){
            this.IsSecret = IsSecret;
            this.IsRestrictedToPartyOnly = IsRestrictedToPartyOnly;
            this.IsClosed = IsClosed;
            this.IsAskingForHelp = IsAskingForHelp;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, IsSecret);
			flag = BooleanByteWrapper.SetFlag(1, flag, IsRestrictedToPartyOnly);
			flag = BooleanByteWrapper.SetFlag(2, flag, IsClosed);
			flag = BooleanByteWrapper.SetFlag(3, flag, IsAskingForHelp);
			writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			IsSecret = BooleanByteWrapper.GetFlag(flag, 0);
			IsRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(flag, 1);
			IsClosed = BooleanByteWrapper.GetFlag(flag, 2);
			IsAskingForHelp = BooleanByteWrapper.GetFlag(flag, 3);
        }
    }
}
