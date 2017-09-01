using Cookie.API.Protocol.Network.Types.Game.Dare;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareSubscribedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6660;

        public DareSubscribedMessage(bool success, bool subscribe, double dareId,
            DareVersatileInformations dareVersatilesInfos)
        {
            Success = success;
            Subscribe = subscribe;
            DareId = dareId;
            DareVersatilesInfos = dareVersatilesInfos;
        }

        public DareSubscribedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Success { get; set; }
        public bool Subscribe { get; set; }
        public double DareId { get; set; }
        public DareVersatileInformations DareVersatilesInfos { get; set; }

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
            Success = BooleanByteWrapper.GetFlag(flag, 0);
            Subscribe = BooleanByteWrapper.GetFlag(flag, 1);
            DareId = reader.ReadDouble();
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }
    }
}