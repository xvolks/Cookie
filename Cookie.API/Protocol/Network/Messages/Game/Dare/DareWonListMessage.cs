using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareWonListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6682;

        public DareWonListMessage(List<double> dareId)
        {
            DareId = dareId;
        }

        public DareWonListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<double> DareId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) DareId.Count);
            for (var dareIdIndex = 0; dareIdIndex < DareId.Count; dareIdIndex++)
                writer.WriteDouble(DareId[dareIdIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var dareIdCount = reader.ReadUShort();
            DareId = new List<double>();
            for (var dareIdIndex = 0; dareIdIndex < dareIdCount; dareIdIndex++)
                DareId.Add(reader.ReadDouble());
        }
    }
}