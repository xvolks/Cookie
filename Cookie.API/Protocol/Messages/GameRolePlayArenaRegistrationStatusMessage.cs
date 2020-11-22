using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaRegistrationStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6284;

        public override ushort MessageID => ProtocolId;

        public bool Registered { get; set; }
        public sbyte Step { get; set; }
        public int BattleMode { get; set; }
        public GameRolePlayArenaRegistrationStatusMessage() { }

        public GameRolePlayArenaRegistrationStatusMessage( bool Registered, sbyte Step, int BattleMode ){
            this.Registered = Registered;
            this.Step = Step;
            this.BattleMode = BattleMode;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Registered);
            writer.WriteSByte(Step);
            writer.WriteInt(BattleMode);
        }

        public override void Deserialize(IDataReader reader)
        {
            Registered = reader.ReadBoolean();
            Step = reader.ReadSByte();
            BattleMode = reader.ReadInt();
        }
    }
}
