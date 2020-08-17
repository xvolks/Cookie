using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    public class TitlesAndOrnamentsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6367;

        public TitlesAndOrnamentsListMessage(List<ushort> titles, List<ushort> ornaments, ushort activeTitle,
            ushort activeOrnament)
        {
            Titles = titles;
            Ornaments = ornaments;
            ActiveTitle = activeTitle;
            ActiveOrnament = activeOrnament;
        }

        public TitlesAndOrnamentsListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> Titles { get; set; }
        public List<ushort> Ornaments { get; set; }
        public ushort ActiveTitle { get; set; }
        public ushort ActiveOrnament { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Titles.Count);
            for (var titlesIndex = 0; titlesIndex < Titles.Count; titlesIndex++)
                writer.WriteVarUhShort(Titles[titlesIndex]);
            writer.WriteShort((short) Ornaments.Count);
            for (var ornamentsIndex = 0; ornamentsIndex < Ornaments.Count; ornamentsIndex++)
                writer.WriteVarUhShort(Ornaments[ornamentsIndex]);
            writer.WriteVarUhShort(ActiveTitle);
            writer.WriteVarUhShort(ActiveOrnament);
        }

        public override void Deserialize(IDataReader reader)
        {
            var titlesCount = reader.ReadUShort();
            Titles = new List<ushort>();
            for (var titlesIndex = 0; titlesIndex < titlesCount; titlesIndex++)
                Titles.Add(reader.ReadVarUhShort());
            var ornamentsCount = reader.ReadUShort();
            Ornaments = new List<ushort>();
            for (var ornamentsIndex = 0; ornamentsIndex < ornamentsCount; ornamentsIndex++)
                Ornaments.Add(reader.ReadVarUhShort());
            ActiveTitle = reader.ReadVarUhShort();
            ActiveOrnament = reader.ReadVarUhShort();
        }
    }
}