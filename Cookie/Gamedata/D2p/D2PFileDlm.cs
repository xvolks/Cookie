using Cookie.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;


namespace Cookie.Gamedata.D2p
{
    internal sealed class D2PFileDlm
    {
        // Methods
        internal D2PFileDlm(string D2pFilePath)
        {
            D2pFileStream = new FileStream(D2pFilePath, FileMode.Open, FileAccess.Read);
            Reader = new BigEndianReader(D2pFileStream);
            FilenameDataDictionnary = new Dictionary<string, int[]>();
            CheckLock = RuntimeHelpers.GetObjectValue(new object());
            byte num = Convert.ToByte((Reader.ReadByte() + Reader.ReadByte()));
            if ((num == 3))
            {
                D2pFileStream.Position = (D2pFileStream.Length - 24);
                int num2 = Convert.ToInt32(Reader.ReadUInt());
                Reader.ReadUInt();
                int num3 = Convert.ToInt32(Reader.ReadUInt());
                int num4 = Convert.ToInt32(Reader.ReadUInt());
                int num1 = Convert.ToInt32(Reader.ReadUInt());
                int num9 = Convert.ToInt32(Reader.ReadUInt());
                D2pFileStream.Position = num3;
                int num5 = num4;
                int i = 1;
                while ((i <= num5))
                {
                    string key = Reader.ReadUTF();
                    int num7 = (Reader.ReadInt() + num2);
                    int num8 = Reader.ReadInt();
                    FilenameDataDictionnary.Add(key, new int[] {
                    num7,
                    num8
                });
                    i += 1;
                }
            }
        }

        internal bool ExistsDlm(string DlmName)
        {
            return FilenameDataDictionnary.ContainsKey(DlmName);
        }

        internal byte[] ReadFile(string fileName)
        {
            lock (CheckLock)
            {
                int[] numArray = FilenameDataDictionnary[fileName];
                D2pFileStream.Position = numArray[0];
                return Reader.ReadBytes(numArray[1]);
            }
        }


        // Fields
        private Dictionary<string, int[]> FilenameDataDictionnary;
        private BigEndianReader Reader;
        private FileStream D2pFileStream;
        private object CheckLock;
    }
}
