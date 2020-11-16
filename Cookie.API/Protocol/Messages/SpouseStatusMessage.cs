using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SpouseStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6265;

        public override ushort MessageID => ProtocolId;

        public bool HasSpouse { get; set; }
        public SpouseStatusMessage() { }

        public SpouseStatusMessage( bool HasSpouse ){
            this.HasSpouse = HasSpouse;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(HasSpouse);
        }

        public override void Deserialize(IDataReader reader)
        {
            HasSpouse = reader.ReadBoolean();
        }
    }
}
