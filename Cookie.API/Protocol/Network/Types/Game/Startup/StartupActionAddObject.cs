using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Data.Items;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Startup
{
    public class StartupActionAddObject : NetworkType
    {
        public const ushort ProtocolId = 52;

        public StartupActionAddObject(int uid, string title, string text, string descUrl, string pictureUrl,
            List<ObjectItemInformationWithQuantity> items)
        {
            Uid = uid;
            Title = title;
            Text = text;
            DescUrl = descUrl;
            PictureUrl = pictureUrl;
            Items = items;
        }

        public StartupActionAddObject()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int Uid { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string DescUrl { get; set; }
        public string PictureUrl { get; set; }
        public List<ObjectItemInformationWithQuantity> Items { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Uid);
            writer.WriteUTF(Title);
            writer.WriteUTF(Text);
            writer.WriteUTF(DescUrl);
            writer.WriteUTF(PictureUrl);
            writer.WriteShort((short) Items.Count);
            for (var itemsIndex = 0; itemsIndex < Items.Count; itemsIndex++)
            {
                var objectToSend = Items[itemsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadInt();
            Title = reader.ReadUTF();
            Text = reader.ReadUTF();
            DescUrl = reader.ReadUTF();
            PictureUrl = reader.ReadUTF();
            var itemsCount = reader.ReadUShort();
            Items = new List<ObjectItemInformationWithQuantity>();
            for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
            {
                var objectToAdd = new ObjectItemInformationWithQuantity();
                objectToAdd.Deserialize(reader);
                Items.Add(objectToAdd);
            }
        }
    }
}