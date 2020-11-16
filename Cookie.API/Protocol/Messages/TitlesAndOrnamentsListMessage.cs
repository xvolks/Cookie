using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TitlesAndOrnamentsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6367;

        public override ushort MessageID => ProtocolId;

        public List<short> Titles { get; set; }
        public List<short> Ornaments { get; set; }
        public ushort ActiveTitle { get; set; }
        public ushort ActiveOrnament { get; set; }
        public TitlesAndOrnamentsListMessage() { }

        public TitlesAndOrnamentsListMessage( List<short> Titles, List<short> Ornaments, ushort ActiveTitle, ushort ActiveOrnament ){
            this.Titles = Titles;
            this.Ornaments = Ornaments;
            this.ActiveTitle = ActiveTitle;
            this.ActiveOrnament = ActiveOrnament;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Titles.Count);
			foreach (var x in Titles)
			{
				writer.WriteVarShort(x);
			}
			writer.WriteShort((short)Ornaments.Count);
			foreach (var x in Ornaments)
			{
				writer.WriteVarShort(x);
			}
            writer.WriteVarUhShort(ActiveTitle);
            writer.WriteVarUhShort(ActiveOrnament);
        }

        public override void Deserialize(IDataReader reader)
        {
            var TitlesCount = reader.ReadShort();
            Titles = new List<short>();
            for (var i = 0; i < TitlesCount; i++)
            {
                Titles.Add(reader.ReadVarShort());
            }
            var OrnamentsCount = reader.ReadShort();
            Ornaments = new List<short>();
            for (var i = 0; i < OrnamentsCount; i++)
            {
                Ornaments.Add(reader.ReadVarShort());
            }
            ActiveTitle = reader.ReadVarUhShort();
            ActiveOrnament = reader.ReadVarUhShort();
        }
    }
}
