using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaRegisterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6280;

        public override ushort MessageID => ProtocolId;

        public int BattleMode { get; set; }
        public GameRolePlayArenaRegisterMessage() { }

        public GameRolePlayArenaRegisterMessage( int BattleMode ){
            this.BattleMode = BattleMode;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(IDataReader reader)
        {
            BattleMode = reader.ReadInt();
        }
    }
}
