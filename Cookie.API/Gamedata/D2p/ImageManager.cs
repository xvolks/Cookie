using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Cookie.API.Gamedata.D2p
{
    public class ImageManager
    {
        public static Dictionary<string, int[]> DictionnaryItemGfx = new Dictionary<string, int[]>();
        private static FileStream Mystream { get; set; }
        private static object MDofusPath { get; set; }

        public static void Init(string dofusPath)
        {
            MDofusPath = dofusPath;
            foreach (var file in Directory.GetFiles(MDofusPath + "\\app\\content\\gfx\\items\\"))
            {
                if (!file.Contains("bitmap")) continue;
                Mystream = new FileStream(file, FileMode.Open, FileAccess.Read);
                var num = Convert.ToByte(Mystream.ReadByte() + Mystream.ReadByte());
                if (num == 3)
                {
                    Mystream.Position = Mystream.Length - 0x18L;
                    var num2 = Convert.ToInt32(ReadUInt());
                    ReadUInt();
                    var num3 = Convert.ToInt32(ReadUInt());
                    var num4 = Convert.ToInt32(ReadUInt());
                    var num1 = Convert.ToInt32(ReadUInt());
                    var num10 = Convert.ToInt32(ReadUInt());
                    Mystream.Position = num3;
                    var num5 = num4;
                    for (var i = 1; i <= num5; i++)
                    {
                        var key = ReadString();
                        var num7 = (int) (ReadUInt() + num2);
                        var num8 = (int) ReadUInt();
                        DictionnaryItemGfx.Add(key, new[]
                        {
                            num7,
                            num8
                        });
                    }
                    Mystream.Close();
                }
            }
        }

        private static short ReadShort()
        {
            return BitConverter.ToInt16(_InverseArray(ReadBytes(2)), 0);
        }

        private static string ReadString()
        {
            int lenght = ReadShort();
            var bytes = ReadBytes(lenght);
            return Encoding.UTF8.GetString(bytes);
        }

        private static byte[] ReadBytes(int lenght)
        {
            var destinationArray = new byte[lenght];
            for (var i = 0; i <= lenght - 1; i++)
                destinationArray[i] = (byte) Mystream.ReadByte();
            return destinationArray;
        }

        private static uint ReadUInt()
        {
            return BitConverter.ToUInt32(_InverseArray(ReadBytes(4)), 0);
        }

        private static byte[] _InverseArray(byte[] source)
        {
            var buffer = new byte[source.Length];
            var i = 0;
            for (i = 0; i <= source.Length - 1; i++)
                buffer[i] = source[source.Length - 1 - i];
            return buffer;
        }

        public static Image GetImage(int IconId)
        {
            for (var i = 0; i <= 1; i++)
                try
                {
                    Image GFXItem = null;
                    Mystream = new FileStream(MDofusPath + "\\app\\content\\gfx\\items\\bitmap" + i + ".d2p",
                        FileMode.Open, FileAccess.Read);
                    var numArray = DictionnaryItemGfx[IconId + ".png"];
                    Mystream.Position = numArray[0];
                    var buffer = ReadBytes(numArray[1]);
                    var stream = new MemoryStream(buffer, 0, buffer.Length);
                    Mystream.Close();
                    GFXItem = Image.FromStream(stream);
                    return GFXItem;
                }
                catch
                {
                }
            return null;
        }
    }
}