using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LivingObjectMessageMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6065;

        public override ushort MessageID => ProtocolId;

        public ushort MsgId { get; set; }
        public int TimeStamp { get; set; }
        public string Owner { get; set; }
        public ushort ObjectGenericId { get; set; }
        public LivingObjectMessageMessage() { }

        public LivingObjectMessageMessage( ushort MsgId, int TimeStamp, string Owner, ushort ObjectGenericId ){
            this.MsgId = MsgId;
            this.TimeStamp = TimeStamp;
            this.Owner = Owner;
            this.ObjectGenericId = ObjectGenericId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(MsgId);
            writer.WriteInt(TimeStamp);
            writer.WriteUTF(Owner);
            writer.WriteVarUhShort(ObjectGenericId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgId = reader.ReadVarUhShort();
            TimeStamp = reader.ReadInt();
            Owner = reader.ReadUTF();
            ObjectGenericId = reader.ReadVarUhShort();
        }
    }
}
