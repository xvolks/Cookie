using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightTurnFinishMessage : NetworkMessage
    {
        public const ushort ProtocolId = 718;

        public override ushort MessageID => ProtocolId;

        public bool IsAfk { get; set; }
        public GameFightTurnFinishMessage() { }

        public GameFightTurnFinishMessage( bool IsAfk ){
            this.IsAfk = IsAfk;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(IsAfk);
        }

        public override void Deserialize(IDataReader reader)
        {
            IsAfk = reader.ReadBoolean();
        }
    }
}
