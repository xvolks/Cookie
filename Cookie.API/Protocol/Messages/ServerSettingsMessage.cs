using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ServerSettingsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6340;

        public override ushort MessageID => ProtocolId;

        public bool IsMonoAccount { get; set; }
        public bool HasFreeAutopilot { get; set; }
        public string Lang { get; set; }
        public sbyte Community { get; set; }
        public sbyte GameType { get; set; }
        public ushort ArenaLeaveBanTime { get; set; }
        public int ItemMaxLevel { get; set; }
        public ServerSettingsMessage() { }

        public ServerSettingsMessage( bool IsMonoAccount, bool HasFreeAutopilot, string Lang, sbyte Community, sbyte GameType, ushort ArenaLeaveBanTime, int ItemMaxLevel ){
            this.IsMonoAccount = IsMonoAccount;
            this.HasFreeAutopilot = HasFreeAutopilot;
            this.Lang = Lang;
            this.Community = Community;
            this.GameType = GameType;
            this.ArenaLeaveBanTime = ArenaLeaveBanTime;
            this.ItemMaxLevel = ItemMaxLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, IsMonoAccount);
			flag = BooleanByteWrapper.SetFlag(1, flag, HasFreeAutopilot);
			writer.WriteByte(flag);
            writer.WriteUTF(Lang);
            writer.WriteSByte(Community);
            writer.WriteSByte(GameType);
            writer.WriteVarUhShort(ArenaLeaveBanTime);
            writer.WriteInt(ItemMaxLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			IsMonoAccount = BooleanByteWrapper.GetFlag(flag, 0);;
			HasFreeAutopilot = BooleanByteWrapper.GetFlag(flag, 1);;
            Lang = reader.ReadUTF();
            Community = reader.ReadSByte();
            GameType = reader.ReadSByte();
            ArenaLeaveBanTime = reader.ReadVarUhShort();
            ItemMaxLevel = reader.ReadInt();
        }
    }
}
