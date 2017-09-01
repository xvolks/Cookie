using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    public class IdolSelectRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6587;

        public IdolSelectRequestMessage(bool activate, bool party, ushort idolId)
        {
            Activate = activate;
            Party = party;
            IdolId = idolId;
        }

        public IdolSelectRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Activate { get; set; }
        public bool Party { get; set; }
        public ushort IdolId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Activate);
            flag = BooleanByteWrapper.SetFlag(1, flag, Party);
            writer.WriteByte(flag);
            writer.WriteVarUhShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Activate = BooleanByteWrapper.GetFlag(flag, 0);
            Party = BooleanByteWrapper.GetFlag(flag, 1);
            IdolId = reader.ReadVarUhShort();
        }
    }
}