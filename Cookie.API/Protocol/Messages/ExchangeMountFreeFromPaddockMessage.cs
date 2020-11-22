using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeMountFreeFromPaddockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6055;

        public override ushort MessageID => ProtocolId;

        public string Name { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public string Liberator { get; set; }
        public ExchangeMountFreeFromPaddockMessage() { }

        public ExchangeMountFreeFromPaddockMessage( string Name, short WorldX, short WorldY, string Liberator ){
            this.Name = Name;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.Liberator = Liberator;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteUTF(Liberator);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            Liberator = reader.ReadUTF();
        }
    }
}
