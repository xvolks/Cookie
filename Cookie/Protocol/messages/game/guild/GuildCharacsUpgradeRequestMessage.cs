using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildCharacsUpgradeRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5706;
        public override uint MessageID { get { return ProtocolId; } }

        public byte CharaTypeTarget = 0;

        public GuildCharacsUpgradeRequestMessage()
        {
        }

        public GuildCharacsUpgradeRequestMessage(
            byte charaTypeTarget
        )
        {
            CharaTypeTarget = charaTypeTarget;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(CharaTypeTarget);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CharaTypeTarget = reader.ReadByte();
        }
    }
}