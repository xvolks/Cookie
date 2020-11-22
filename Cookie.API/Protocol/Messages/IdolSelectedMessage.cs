using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdolSelectedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6581;

        public override ushort MessageID => ProtocolId;

        public bool Activate { get; set; }
        public bool Party { get; set; }
        public ushort IdolId { get; set; }
        public IdolSelectedMessage() { }

        public IdolSelectedMessage( bool Activate, bool Party, ushort IdolId ){
            this.Activate = Activate;
            this.Party = Party;
            this.IdolId = IdolId;
        }

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
			Activate = BooleanByteWrapper.GetFlag(flag, 0);;
			Party = BooleanByteWrapper.GetFlag(flag, 1);;
            IdolId = reader.ReadVarUhShort();
        }
    }
}
