using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareSubscribedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6660;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Success = false;
        public bool Subscribe = false;
        public double DareId = 0;
        public DareVersatileInformations DareVersatilesInfos;

        public DareSubscribedMessage()
        {
        }

        public DareSubscribedMessage(
            bool success,
            bool subscribe,
            double dareId,
            DareVersatileInformations dareVersatilesInfos
        )
        {
            Success = success;
            Subscribe = subscribe;
            DareId = dareId;
            DareVersatilesInfos = dareVersatilesInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Success);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Subscribe);
            writer.WriteByte(box0);
            writer.WriteDouble(DareId);
            DareVersatilesInfos.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Success = BooleanByteWrapper.GetFlag(box0, 1);
            Subscribe = BooleanByteWrapper.GetFlag(box0, 2);
            DareId = reader.ReadDouble();
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }
    }
}