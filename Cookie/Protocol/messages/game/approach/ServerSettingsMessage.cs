using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ServerSettingsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6340;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsMonoAccount = false;
        public bool HasFreeAutopilot = false;
        public string Lang;
        public byte Community = 0;
        public byte GameType = unchecked((byte)-1);
        public short ArenaLeaveBanTime = 0;
        public int ItemMaxLevel = 0;

        public ServerSettingsMessage()
        {
        }

        public ServerSettingsMessage(
            bool isMonoAccount,
            bool hasFreeAutopilot,
            string lang,
            byte community,
            byte gameType,
            short arenaLeaveBanTime,
            int itemMaxLevel
        )
        {
            IsMonoAccount = isMonoAccount;
            HasFreeAutopilot = hasFreeAutopilot;
            Lang = lang;
            Community = community;
            GameType = gameType;
            ArenaLeaveBanTime = arenaLeaveBanTime;
            ItemMaxLevel = itemMaxLevel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, IsMonoAccount);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, HasFreeAutopilot);
            writer.WriteByte(box0);
            writer.WriteUTF(Lang);
            writer.WriteByte(Community);
            writer.WriteByte(GameType);
            writer.WriteVarShort(ArenaLeaveBanTime);
            writer.WriteInt(ItemMaxLevel);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            IsMonoAccount = BooleanByteWrapper.GetFlag(box0, 1);
            HasFreeAutopilot = BooleanByteWrapper.GetFlag(box0, 2);
            Lang = reader.ReadUTF();
            Community = reader.ReadByte();
            GameType = reader.ReadByte();
            ArenaLeaveBanTime = reader.ReadVarShort();
            ItemMaxLevel = reader.ReadInt();
        }
    }
}