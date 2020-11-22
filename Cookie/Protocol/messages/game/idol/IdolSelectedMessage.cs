using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdolSelectedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6581;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Activate = false;
        public bool Party = false;
        public short IdolId = 0;

        public IdolSelectedMessage()
        {
        }

        public IdolSelectedMessage(
            bool activate,
            bool party,
            short idolId
        )
        {
            Activate = activate;
            Party = party;
            IdolId = idolId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Activate);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Party);
            writer.WriteByte(box0);
            writer.WriteVarShort(IdolId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Activate = BooleanByteWrapper.GetFlag(box0, 1);
            Party = BooleanByteWrapper.GetFlag(box0, 2);
            IdolId = reader.ReadVarShort();
        }
    }
}