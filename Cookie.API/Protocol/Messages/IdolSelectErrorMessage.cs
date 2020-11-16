using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdolSelectErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6584;

        public override ushort MessageID => ProtocolId;

        public bool Activate { get; set; }
        public bool Party { get; set; }
        public sbyte Reason { get; set; }
        public ushort IdolId { get; set; }
        public IdolSelectErrorMessage() { }

        public IdolSelectErrorMessage( bool Activate, bool Party, sbyte Reason, ushort IdolId ){
            this.Activate = Activate;
            this.Party = Party;
            this.Reason = Reason;
            this.IdolId = IdolId;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Activate);
			flag = BooleanByteWrapper.SetFlag(1, flag, Party);
			writer.WriteByte(flag);
            writer.WriteSByte(Reason);
            writer.WriteVarUhShort(IdolId);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Activate = BooleanByteWrapper.GetFlag(flag, 0);;
			Party = BooleanByteWrapper.GetFlag(flag, 1);;
            Reason = reader.ReadSByte();
            IdolId = reader.ReadVarUhShort();
        }
    }
}
