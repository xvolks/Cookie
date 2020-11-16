using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p
{
    public class MapsManager
    {
        // Fields
        private static D2pFileManager D2pFileManager;

        private static Dictionary<double, Map> MapId_Map;

        private static object CheckLock;

        // Methods
        public static Map FromId(double id)
        {
            lock (CheckLock)
            {
                if (MapId_Map.Count > 20)
                    MapId_Map.Remove(MapId_Map.Keys.First());

                if (MapId_Map.ContainsKey(id))
                    return MapId_Map[id];

                var str = id % 10 + "/" + id + ".dlm";
                var mapBytes = D2pFileManager.GetMapBytes(str);
                if (mapBytes != null)
                {

                    MemoryStream stream = new MemoryStream();
                    using (MemoryStream decompressMapStream = new MemoryStream(mapBytes) { Position = 2 })
                    using (DeflateStream mapDeflateStream = new DeflateStream(decompressMapStream, CompressionMode.Decompress))
                    { 
                        mapDeflateStream.CopyTo(stream);
                    }
                    stream.Position = 0;
                    //Console.WriteLine(BitConverter.ToString(stream.ToArray()).Replace("-",""));
                    BigEndianReader Raw = new BigEndianReader(stream);
                    Map map = new Map();
                    map.Init(Raw);
                    return map;
                }
                MapId_Map.Add(id, null);
                return null;
            }
        }

        public static void Init(string directory)
        {
            MapId_Map = new Dictionary<double, Map>();
            D2pFileManager = new D2pFileManager(directory);
            CheckLock = new object();
        }
    }
}