#region License GNU GPL
// D2iFile.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#endregion
using Cookie.IO;
using System.Collections.Generic;
using System.IO;

namespace Cookie.Gamedata.D2i
{
    public class D2iFile
    {
        private readonly string uri;
        private readonly Dictionary<string, string> textIndexes = new Dictionary<string, string>();
        private readonly Dictionary<int, string> indexes = new Dictionary<int, string>();

        public D2iFile(string uri)
        {
            this.uri = uri;
            Initialize();
        }

        public string FilePath
        {
            get { return uri; }
        }

        private void Initialize()
        {
            using (var reader = new FastBigEndianReader(File.ReadAllBytes(uri)))
            {
                var indexPos = reader.ReadInt();
                reader.Seek(indexPos, SeekOrigin.Begin);
                var indexLen = reader.ReadInt();
                int addOffset = 0;
                for (int i = 0; i < indexLen; i += 9)
                {
                    var key = reader.ReadInt();
                    byte nbAdditionnalStrings = reader.ReadByte();                    
                    var dataPos = reader.ReadInt();
                    var pos = (int)reader.Position;
                    reader.Seek(dataPos + addOffset, SeekOrigin.Begin);
                    indexes.Add(key, reader.ReadUTF());
                    reader.Seek(pos, SeekOrigin.Begin);
                    while (nbAdditionnalStrings-- > 0)
                    {
                        dataPos = reader.ReadInt();
                        pos = (int)reader.Position;
                        reader.Seek(dataPos + addOffset, SeekOrigin.Begin);
                        string unusedString = reader.ReadUTF(); // Well, no real use to read that, as we don't use 'em
                        reader.Seek(pos, SeekOrigin.Begin);
                        i += 4;
                    }
                }
                int lastOffset = reader.ReadInt() + (int)reader.Position;
                
                int locpos = (int)reader.Position;

                while (locpos < lastOffset)
                {
                    var key = reader.ReadUTF();
                    var dataPos = reader.ReadInt();
                    locpos = (int)reader.Position;
                    reader.Seek(dataPos, SeekOrigin.Begin);
                    textIndexes.Add(key, reader.ReadUTF());
                    reader.Seek(locpos, SeekOrigin.Begin);
                }
            }
        }

        public string GetText(int id)
        {
            if (indexes.ContainsKey(id))
            {
                return indexes[id];
            }
            return "{null}";
        }

        public string GetText(string id)
        {
            if (textIndexes.ContainsKey(id))
            {
                return textIndexes[id];
            }
            return "{null}";
        }

        public void SetText(int id, string value)
        {
            if (indexes.ContainsKey(id))
                indexes[id] = value;
            else
                indexes.Add(id, value);
        }

        public void SetText(string id, string value)
        {
            if (textIndexes.ContainsKey(id))
                textIndexes[id] = value;
            else
                textIndexes.Add(id, value);
        }

        public Dictionary<int, string> GetAllText()
        {
            return indexes;
        }

        public Dictionary<string, string> GetAllUiText()
        {
            return textIndexes;
        }

        public void Save()
        {
            Save(uri);
        }

        public void Save(string uri)
        {
            using (var writer = new BigEndianWriter(new StreamWriter(uri).BaseStream))
            {
                var indexTable = new BigEndianWriter();
                writer.Seek(4, SeekOrigin.Begin);

                foreach (var index in indexes)
                {
                    indexTable.WriteInt(index.Key);
                    indexTable.WriteInt((int)writer.Position);
                    writer.WriteUTF(index.Value);
                }

                var indexLen = (int)indexTable.Position;

                foreach (var index in textIndexes)
                {
                    indexTable.WriteUTF(index.Key);
                    indexTable.WriteInt((int)writer.Position);
                    writer.WriteUTF(index.Value);
                }

                var indexPos = (int)writer.Position;

                /* write index at end */
                var indexData = indexTable.Data;
                writer.WriteInt(indexLen);
                writer.WriteBytes(indexData);

                /* write index pos at begin */
                writer.Seek(0, SeekOrigin.Begin);
                writer.WriteInt(indexPos);
            }
        }
    }
}
