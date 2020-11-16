using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Cookie.API.Network;
using Cookie.API.Utils;
using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p
{
    public struct FilePosition
    {
        public int offset { get; set; }
        public int length { get; set; }
        public FilePosition(int offset, int length)
        {
            this.offset = offset;
            this.length = length;
        }
    }
    internal sealed class D2PFileDlm
    {
        private readonly object CheckLock;
        private readonly FileStream D2pFileStream;
        private readonly byte[] Header = { 0x02, 0x01 };
        private bool isInitialized = false;
        private Dictionary<string,string> Properties;

        public Dictionary<string, FilePosition> FilePositionDictionary;
        // Fields
        //private readonly Dictionary<string, int[]> FilenameDataDictionnary;

        private readonly BigEndianReader Reader;

        // Methods
        internal D2PFileDlm(string D2pFilePath)
        {

            D2pFileStream = new FileStream(D2pFilePath, FileMode.Open, FileAccess.Read);
            Reader = new BigEndianReader(D2pFileStream);
            CheckLock = RuntimeHelpers.GetObjectValue(new object());
            byte[] bytes_header = Reader.ReadBytes(2);
            if (bytes_header.SequenceEqual(Header))
            {
                Reader.BaseStream.Seek(-24, SeekOrigin.End);
                uint BaseOffset = Reader.ReadUInt();
                uint BaseLength = Reader.ReadUInt();
                uint IndexesOffset = Reader.ReadUInt();
                uint NumberIndexes = Reader.ReadUInt();
                uint PropertiesOffset = Reader.ReadUInt();
                uint NumberProperties = Reader.ReadUInt();

                //if (BaseOffset == 0 || BaseLength == 0 || IndexesOffset == 0 || NumberIndexes == 0 || PropertiesOffset == 0 || NumberProperties == 0)
                    //throw new Exception("The file doesn't match the D2P Pattern");

                Reader.BaseStream.Seek(IndexesOffset, SeekOrigin.Begin);

                #region Read Indexers
                FilePositionDictionary = new Dictionary<string, FilePosition>();
                var i = 0;
                while (i < NumberIndexes)
                {
                    FilePositionDictionary.Add(Reader.ReadUTF(), new FilePosition(Reader.ReadInt(), Reader.ReadInt()));
                    i++;
                }
                #endregion

                Reader.BaseStream.Seek(PropertiesOffset, SeekOrigin.Begin);
                #region Read Properties
                Properties = new Dictionary<string, string>();
                i = 0;
                while (i < NumberProperties)
                {
                    Properties.Add(Reader.ReadUTF(), Reader.ReadUTF());
                    i++;
                }
                #endregion
                isInitialized = true;
            }
            else
                throw new Exception(string.Format("Header on file {0} not valid", D2pFilePath));
        }

        internal bool ExistsDlm(string DlmName)
        {
            if (!isInitialized)
                throw new Exception("D2PFileDlm Not initialized");
            return FilePositionDictionary.ContainsKey(DlmName);
        }

        internal byte[] ReadFile(string fileName)
        {
            if (!isInitialized)
                throw new Exception("D2PFileDlm Not initialized");
            lock (CheckLock)
            {
                var filePosition = FilePositionDictionary[fileName];
                Reader.BaseStream.Seek(filePosition.offset + 2 , SeekOrigin.Begin); // +  2 is that so we can remove the header
                return Reader.ReadBytes(filePosition.length);
            }
        }
    }
}