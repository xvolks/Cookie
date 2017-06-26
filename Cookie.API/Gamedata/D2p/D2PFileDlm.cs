using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p
{
    internal sealed class D2PFileDlm
    {
        private readonly object CheckLock;
        private readonly FileStream D2pFileStream;


        // Fields
        private readonly Dictionary<string, int[]> FilenameDataDictionnary;

        private readonly BigEndianReader Reader;

        // Methods
        internal D2PFileDlm(string D2pFilePath)
        {
            D2pFileStream = new FileStream(D2pFilePath, FileMode.Open, FileAccess.Read);
            Reader = new BigEndianReader(D2pFileStream);
            FilenameDataDictionnary = new Dictionary<string, int[]>();
            CheckLock = RuntimeHelpers.GetObjectValue(new object());
            var num = Convert.ToByte(Reader.ReadByte() + Reader.ReadByte());
            if (num == 3)
            {
                D2pFileStream.Position = D2pFileStream.Length - 24;
                var num2 = Convert.ToInt32(Reader.ReadUInt());
                Reader.ReadUInt();
                var num3 = Convert.ToInt32(Reader.ReadUInt());
                var num4 = Convert.ToInt32(Reader.ReadUInt());
                var num1 = Convert.ToInt32(Reader.ReadUInt());
                var num9 = Convert.ToInt32(Reader.ReadUInt());
                D2pFileStream.Position = num3;
                var num5 = num4;
                var i = 1;
                while (i <= num5)
                {
                    var key = Reader.ReadUTF();
                    var num7 = Reader.ReadInt() + num2;
                    var num8 = Reader.ReadInt();
                    FilenameDataDictionnary.Add(key, new[]
                    {
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
                var numArray = FilenameDataDictionnary[fileName];
                D2pFileStream.Position = numArray[0];
                return Reader.ReadBytes(numArray[1]);
            }
        }
    }
}