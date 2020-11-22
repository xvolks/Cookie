using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareSubscribedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6660;

        public override ushort MessageID => ProtocolId;

        public bool Success { get; set; }
        public bool Subscribe { get; set; }
        public double DareId { get; set; }
        public DareVersatileInformations DareVersatilesInfos { get; set; }
        public DareSubscribedMessage() { }

        public DareSubscribedMessage( bool Success, bool Subscribe, double DareId, DareVersatileInformations DareVersatilesInfos ){
            this.Success = Success;
            this.Subscribe = Subscribe;
            this.DareId = DareId;
            this.DareVersatilesInfos = DareVersatilesInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Success);
			flag = BooleanByteWrapper.SetFlag(1, flag, Subscribe);
			writer.WriteByte(flag);
            writer.WriteDouble(DareId);
            DareVersatilesInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Success = BooleanByteWrapper.GetFlag(flag, 0);;
			Subscribe = BooleanByteWrapper.GetFlag(flag, 1);;
            DareId = reader.ReadDouble();
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }
    }
}
