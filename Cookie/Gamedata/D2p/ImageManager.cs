using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Cookie.Gamedata.D2p
{
    public class ImageManager
    {
        private static FileStream Mystream { get; set; }
        private static object MDofusPath { get; set; }

        public static Dictionary<string, int[]> DictionnaryItemGfx = new Dictionary<string, int[]>();
        public static void Init(string dofusPath)
        {
            MDofusPath = dofusPath;
            foreach (var file in Directory.GetFiles(MDofusPath + "\\app\\content\\gfx\\items\\"))
            {
                if (!file.Contains("bitmap")) continue;
                Mystream = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte num = Convert.ToByte(Mystream.ReadByte() + Mystream.ReadByte());
                if (num == 3)
                {
                    Mystream.Position = Mystream.Length - 0x18L;
                    int num2 = Convert.ToInt32(ReadUInt());
                    ReadUInt();
                    int num3 = Convert.ToInt32(ReadUInt());
                    int num4 = Convert.ToInt32(ReadUInt());
                    int num1 = Convert.ToInt32(ReadUInt());
                    int num10 = Convert.ToInt32(ReadUInt());
                    Mystream.Position = num3;
                    int num5 = num4;
                    for (int i = 1; i <= num5; i++)
                    {
                        string key = ReadString();
                        int num7 = (int)(ReadUInt() + num2);
                        int num8 = (int)(ReadUInt());
                        DictionnaryItemGfx.Add(key, new int[] {
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
            int lenght = ImageManager.ReadShort();
            byte[] bytes = ImageManager.ReadBytes(lenght);
            return Encoding.UTF8.GetString(bytes);
        }

        private static byte[] ReadBytes(int lenght)
        {
            byte[] destinationArray = new byte[lenght];
            for (int i = 0; i <= lenght - 1; i++)
            {
                destinationArray[i] = (byte)Mystream.ReadByte();
            }
            return destinationArray;
        }

        private static UInt32 ReadUInt()
        {
            return BitConverter.ToUInt32(ImageManager._InverseArray(ImageManager.ReadBytes(4)), 0);
        }

        private static byte[] _InverseArray(byte[] source)
        {
            byte[] buffer = new byte[source.Length];
            int i = 0;
            for (i = 0; i <= source.Length - 1; i++)
            {
                buffer[i] = source[((source.Length - 1) - i)];
            }
            return buffer;
        }

        public static Image GetImage(int IconId)
        {
            for (int i = 0; i <= 1; i++)
            {
                try
                {
                    Image GFXItem = null;
                    Mystream = new FileStream(MDofusPath + "\\app\\content\\gfx\\items\\bitmap" + i + ".d2p", FileMode.Open, FileAccess.Read);
                    int[] numArray = DictionnaryItemGfx[IconId.ToString() + ".png"];
                    Mystream.Position = numArray[0];
                    byte[] buffer = ReadBytes(numArray[1]);
                    MemoryStream stream = new MemoryStream(buffer, 0, buffer.Length);
                    Mystream.Close();
                    GFXItem = Image.FromStream(stream);
                    return GFXItem;
                }
                catch
                {
                }
            }
            return null;
        }
    }
}
