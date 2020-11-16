using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HavenBagDailyLoteryMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6644;

        public override ushort MessageID => ProtocolId;

        public sbyte ReturnType { get; set; }
        public string GameActionId { get; set; }
        public HavenBagDailyLoteryMessage() { }

        public HavenBagDailyLoteryMessage( sbyte ReturnType, string GameActionId ){
            this.ReturnType = ReturnType;
            this.GameActionId = GameActionId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(ReturnType);
            writer.WriteUTF(GameActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ReturnType = reader.ReadSByte();
            GameActionId = reader.ReadUTF();
        }
    }
}
