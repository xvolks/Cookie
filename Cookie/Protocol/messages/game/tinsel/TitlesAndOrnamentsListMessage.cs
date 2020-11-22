using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TitlesAndOrnamentsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6367;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> Titles;
        public List<short> Ornaments;
        public short ActiveTitle = 0;
        public short ActiveOrnament = 0;

        public TitlesAndOrnamentsListMessage()
        {
        }

        public TitlesAndOrnamentsListMessage(
            List<short> titles,
            List<short> ornaments,
            short activeTitle,
            short activeOrnament
        )
        {
            Titles = titles;
            Ornaments = ornaments;
            ActiveTitle = activeTitle;
            ActiveOrnament = activeOrnament;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Titles.Count());
            foreach (var current in Titles)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)Ornaments.Count());
            foreach (var current in Ornaments)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteVarShort(ActiveTitle);
            writer.WriteVarShort(ActiveOrnament);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countTitles = reader.ReadShort();
            Titles = new List<short>();
            for (short i = 0; i < countTitles; i++)
            {
                Titles.Add(reader.ReadVarShort());
            }
            var countOrnaments = reader.ReadShort();
            Ornaments = new List<short>();
            for (short i = 0; i < countOrnaments; i++)
            {
                Ornaments.Add(reader.ReadVarShort());
            }
            ActiveTitle = reader.ReadVarShort();
            ActiveOrnament = reader.ReadVarShort();
        }
    }
}