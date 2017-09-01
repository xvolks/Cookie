using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    public class IdolSelectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6584;

        public IdolSelectErrorMessage(bool activate, bool party, byte reason, ushort idolId)
        {
            Activate = activate;
            Party = party;
            Reason = reason;
            IdolId = idolId;
        }

        public IdolSelectErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Activate { get; set; }
        public bool Party { get; set; }
        public byte Reason { get; set; }
        public ushort IdolId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Activate);
            flag = BooleanByteWrapper.SetFlag(1, flag, Party);
            writer.WriteByte(flag);
            writer.WriteByte(Reason);
            writer.WriteVarUhShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Activate = BooleanByteWrapper.GetFlag(flag, 0);
            Party = BooleanByteWrapper.GetFlag(flag, 1);
            Reason = reader.ReadByte();
            IdolId = reader.ReadVarUhShort();
        }
    }
}