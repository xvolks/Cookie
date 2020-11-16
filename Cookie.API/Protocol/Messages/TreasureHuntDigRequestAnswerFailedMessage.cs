using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntDigRequestAnswerFailedMessage : TreasureHuntDigRequestAnswerMessage
    {
        public new const ushort ProtocolId = 6509;

        public override ushort MessageID => ProtocolId;

        public sbyte WrongFlagCount { get; set; }
        public TreasureHuntDigRequestAnswerFailedMessage() { }

        public TreasureHuntDigRequestAnswerFailedMessage( sbyte WrongFlagCount ){
            this.WrongFlagCount = WrongFlagCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(WrongFlagCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WrongFlagCount = reader.ReadSByte();
        }
    }
}
