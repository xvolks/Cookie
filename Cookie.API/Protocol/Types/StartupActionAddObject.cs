using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class StartupActionAddObject : NetworkType
    {
        public const ushort ProtocolId = 52;

        public override ushort TypeID => ProtocolId;

        public int Uid { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string DescUrl { get; set; }
        public string PictureUrl { get; set; }
        public List<ObjectItemInformationWithQuantity> Items { get; set; }
        public StartupActionAddObject() { }

        public StartupActionAddObject( int Uid, string Title, string Text, string DescUrl, string PictureUrl, List<ObjectItemInformationWithQuantity> Items ){
            this.Uid = Uid;
            this.Title = Title;
            this.Text = Text;
            this.DescUrl = DescUrl;
            this.PictureUrl = PictureUrl;
            this.Items = Items;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Uid);
            writer.WriteUTF(Title);
            writer.WriteUTF(Text);
            writer.WriteUTF(DescUrl);
            writer.WriteUTF(PictureUrl);
			writer.WriteShort((short)Items.Count);
			foreach (var x in Items)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadInt();
            Title = reader.ReadUTF();
            Text = reader.ReadUTF();
            DescUrl = reader.ReadUTF();
            PictureUrl = reader.ReadUTF();
            var ItemsCount = reader.ReadShort();
            Items = new List<ObjectItemInformationWithQuantity>();
            for (var i = 0; i < ItemsCount; i++)
            {
                var objectToAdd = new ObjectItemInformationWithQuantity();
                objectToAdd.Deserialize(reader);
                Items.Add(objectToAdd);
            }
        }
    }
}
