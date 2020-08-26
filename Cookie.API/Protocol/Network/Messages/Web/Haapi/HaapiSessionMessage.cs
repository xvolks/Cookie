using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Utils.IO;
namespace Cookie.API.Protocol.Network.Messages.Web.Haapi
{
   public class HaapiSessionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6769;
        public override ushort MessageID => ProtocolId;
        public string Key { get; set; }
        public byte Type { get; set; }
        public HaapiSessionMessage() { }
        public HaapiSessionMessage(byte type, string key)
        {
            Key = key;
            Type = type;
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Key);
            writer.WriteByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Key = reader.ReadUTF();
            Type = reader.ReadByte();
        }
    }
}
