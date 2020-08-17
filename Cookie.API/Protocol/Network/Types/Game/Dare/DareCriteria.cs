using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Dare
{
    public class DareCriteria : NetworkType
    {
        public const ushort ProtocolId = 501;

        public DareCriteria(byte type, List<int> @params)
        {
            Type = type;
            Params = @params;
        }

        public DareCriteria()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Type { get; set; }
        public List<int> Params { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
            writer.WriteShort((short) Params.Count);
            for (var paramsIndex = 0; paramsIndex < Params.Count; paramsIndex++)
                writer.WriteInt(Params[paramsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
            var paramsCount = reader.ReadUShort();
            Params = new List<int>();
            for (var paramsIndex = 0; paramsIndex < paramsCount; paramsIndex++)
                Params.Add(reader.ReadInt());
        }
    }
}