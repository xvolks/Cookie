using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildCharacsUpgradeRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5706;

        public override ushort MessageID => ProtocolId;

        public sbyte CharaTypeTarget { get; set; }
        public GuildCharacsUpgradeRequestMessage() { }

        public GuildCharacsUpgradeRequestMessage( sbyte CharaTypeTarget ){
            this.CharaTypeTarget = CharaTypeTarget;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(CharaTypeTarget);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharaTypeTarget = reader.ReadSByte();
        }
    }
}
