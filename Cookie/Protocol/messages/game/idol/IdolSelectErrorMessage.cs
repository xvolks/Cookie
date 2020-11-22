using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolSelectErrorMessage : NetworkMessage
    {
        public const uint ProtocolId = 6584;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Activate = false;
        public bool Party = false;
        public byte Reason = 0;
        public short IdolId = 0;

        public IdolSelectErrorMessage()
        {
        }

        public IdolSelectErrorMessage(
            bool activate,
            bool party,
            byte reason,
            short idolId
        )
        {
            Activate = activate;
            Party = party;
            Reason = reason;
            IdolId = idolId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Activate);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Party);
            writer.WriteByte(box0);
            writer.WriteByte(Reason);
            writer.WriteVarShort(IdolId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Activate = BooleanByteWrapper.GetFlag(box0, 1);
            Party = BooleanByteWrapper.GetFlag(box0, 2);
            Reason = reader.ReadByte();
            IdolId = reader.ReadVarShort();
        }
    }
}