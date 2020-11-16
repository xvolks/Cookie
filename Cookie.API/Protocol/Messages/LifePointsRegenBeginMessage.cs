using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LifePointsRegenBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5684;

        public override ushort MessageID => ProtocolId;

        public byte RegenRate { get; set; }
        public LifePointsRegenBeginMessage() { }

        public LifePointsRegenBeginMessage( byte RegenRate ){
            this.RegenRate = RegenRate;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(RegenRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            RegenRate = reader.ReadByte();
        }
    }
}
