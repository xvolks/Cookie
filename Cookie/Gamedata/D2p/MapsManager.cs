using Cookie.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Cookie.Gamedata.D2p
{
    public class MapsManager
    {
        // Methods
        public static Map FromId(int id)
        {
            lock (CheckLock)
            {
                if ((MapId_Map.Count > 20))
                    MapId_Map.Remove(MapId_Map.Keys.First());

                if (MapId_Map.ContainsKey(id))
                    return MapId_Map[id];

                string str = ((id % 10).ToString() + "/" + id.ToString() + ".dlm");
                byte[] mapBytes = D2pFileManager.GetMapBytes(str);
                if (mapBytes != null)
                {
                    MemoryStream stream = new MemoryStream(D2pFileManager.GetMapBytes(str)) { Position = 2 };
                    DeflateStream stream2 = new DeflateStream(stream, CompressionMode.Decompress);
                    byte[] buffer = new byte[8192];
                    MemoryStream destination = new MemoryStream();
                    int read;
                    while ((read = stream2.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destination.Write(buffer, 0, read);
                    }
                    destination.Position = 0;
                    BigEndianReader reader = new BigEndianReader(destination);
                    Map map = new Map();
                    map.Init(reader);
                    MapId_Map.Add(id, map);
                    Array.Clear(mapBytes, 0, mapBytes.Length);
                    return map;
                }
                MapId_Map.Add(id, null);
                return null;
            }
        }

        public static void Init(string directory)
        {
            MapId_Map = new Dictionary<int, Map>();
            D2pFileManager = new D2pFileManager(directory);
            CheckLock = new object();
        }

        // Fields
        private static D2pFileManager D2pFileManager;
        private static Dictionary<int, Map> MapId_Map;
        private static object CheckLock;
    }
}
