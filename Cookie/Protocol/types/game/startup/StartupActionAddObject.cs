using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class StartupActionAddObject : NetworkType
    {
        public const short ProtocolId = 52;
        public override short TypeId { get { return ProtocolId; } }

        public int Uid = 0;
        public string Title;
        public string Text;
        public string DescUrl;
        public string PictureUrl;
        public List<ObjectItemInformationWithQuantity> Items;

        public StartupActionAddObject()
        {
        }

        public StartupActionAddObject(
            int uid,
            string title,
            string text,
            string descUrl,
            string pictureUrl,
            List<ObjectItemInformationWithQuantity> items
        )
        {
            Uid = uid;
            Title = title;
            Text = text;
            DescUrl = descUrl;
            PictureUrl = pictureUrl;
            Items = items;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(Uid);
            writer.WriteUTF(Title);
            writer.WriteUTF(Text);
            writer.WriteUTF(DescUrl);
            writer.WriteUTF(PictureUrl);
            writer.WriteShort((short)Items.Count());
            foreach (var current in Items)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Uid = reader.ReadInt();
            Title = reader.ReadUTF();
            Text = reader.ReadUTF();
            DescUrl = reader.ReadUTF();
            PictureUrl = reader.ReadUTF();
            var countItems = reader.ReadShort();
            Items = new List<ObjectItemInformationWithQuantity>();
            for (short i = 0; i < countItems; i++)
            {
                ObjectItemInformationWithQuantity type = new ObjectItemInformationWithQuantity();
                type.Deserialize(reader);
                Items.Add(type);
            }
        }
    }
}