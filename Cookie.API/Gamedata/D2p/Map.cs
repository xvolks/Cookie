using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cookie.API.Game.Map;
using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2p
{
    public class Map : IMap, IMapData
    {
        public Map()
        {
            BackgroundFixtures = new List<Fixture>();
            ForegroundFixtures = new List<Fixture>();
            Layers = new List<Layer>();
        }

        public long BackgroundAlpha { get; set; }
        public int BackgroundBlue { get; set; }
        public List<Fixture> BackgroundFixtures { get; set; }
        public int BackgroundGreen { get; set; }
        public int BackgroundRed { get; set; }
        public int BackgroundColor { get; set; }
        public int BackgroundsCount { get; set; }
        public int BottomNeighbourId { get; set; }
        public bool Encrypted { get; set; }
        public int EncryptedVersion { get; set; }
        public List<Fixture> ForegroundFixtures { get; set; }
        public int ForegroundsCount { get; set; }
        public uint GridAlpha { get; set; }
        public uint GridBlue { get; set; }
        public uint GridGreen { get; set; }
        public uint GridRed { get; set; }
        public uint GridColor { get; set; }
        public string GroundCRC { get; set; }
        public double Id { get; set; }
        public bool IsUsingNewMovementSystem { get; set; }
        public List<Layer> Layers { get; set; }
        public int LayersCount { get; set; }
        public int LeftNeighbourId { get; set; }
        public int MapType { get; set; }
        public int MapVersion { get; set; }
        public int PresetId { get; set; }
        public uint RelativeId { get; set; }
        public int RightNeighbourId { get; set; }
        public int ShadowBonusOnEntities { get; set; }
        public int SubAreaId { get; set; }
        public int TopNeighbourId { get; set; }
        public bool UseLowPassFilter { get; set; }
        public bool UseReverb { get; set; }
        public int ZoomOffsetX { get; set; }
        public int ZoomOffsetY { get; set; }
        public double ZoomScale { get; set; }
        public List<CellData> Cells { get; } = new List<CellData>();
        public int CellsCount { get; private set; }
        public int TacticalModeTempladeId { get; set; }

        public List<int> TopArrowCell, BottomArrowCell, RightArrowCell, LeftArrowCell = new List<int>();
        public bool IsLineOfSight(int cellId)
        {
            return cellId >= 0 && cellId < CellsCount && Cells[cellId].Los;
        }

        public bool IsWalkable(int cellId)
        {
            return cellId >= 0 && cellId < CellsCount && Cells[cellId].Mov;
        }

        internal void Init(BigEndianReader reader)
        {
            byte header = reader.ReadByte();
            if (header != 77)
                throw new Exception("Header cannot be different than 77");
            MapVersion = reader.ReadSByte();
            Id = reader.ReadUInt();
            if (MapVersion >= 7)
            {
                Encrypted = reader.ReadBoolean();
                EncryptedVersion = reader.ReadSByte();
                int dataLen = reader.ReadInt();
                if (Encrypted)
                {
                    byte[] key = Encoding.UTF8.GetBytes("649ae451ca33ec53bbcbcc33becf15f4");
                    var encryptedData = reader.ReadBytes(dataLen);
                    System.IO.MemoryStream decryptedData = new System.IO.MemoryStream();
                    for (int i = 0; i < dataLen; i++)
                        decryptedData.WriteByte((byte)(encryptedData[i] ^ (key[i % key.Length])));

                    reader = new BigEndianReader(decryptedData.ToArray());
                }
            }

            RelativeId = reader.ReadUInt();
            MapType = reader.ReadSByte();
            SubAreaId = reader.ReadInt();
            TopNeighbourId = reader.ReadInt();
            BottomNeighbourId = reader.ReadInt();
            LeftNeighbourId = reader.ReadInt();
            RightNeighbourId = reader.ReadInt();
            ShadowBonusOnEntities = reader.ReadInt();

            if (MapVersion >= 9)
            {
                int color = reader.ReadInt();
                BackgroundAlpha = (color & 4278190080) >> 32;
                BackgroundRed = (color & 16711680) >> 16;
                BackgroundGreen = (color & 65280) >> 8;
                BackgroundBlue = (color & 255);
                uint gridColor = reader.ReadUInt();
                GridAlpha = (gridColor & 4278190080) >> 32;
                GridRed = (gridColor & 16711680) >> 16;
                GridGreen = (gridColor & 65280) >> 8;
                GridBlue = (gridColor & 255);
                GridColor = (GridAlpha & 255) << 32 | (GridRed & 255) << 16 | (GridGreen & 255) << 8 | (GridBlue & 255);
            }
            else if (MapVersion >= 3) 
            {
                BackgroundRed = reader.ReadSByte();
                BackgroundGreen = reader.ReadSByte();
                BackgroundBlue = reader.ReadSByte();
            }
            BackgroundColor = (BackgroundRed & 255) << 16 | (BackgroundGreen & 255) << 8 | (BackgroundBlue & 255);
            if(MapVersion >= 4)
            {
                ZoomScale = Convert.ToDouble(reader.ReadUShort() / 100);
                ZoomOffsetX = Convert.ToInt32(reader.ReadShort());
                ZoomOffsetY = Convert.ToInt32(reader.ReadShort());
                if(ZoomScale < 1)
                {
                    ZoomScale = 1;
                    ZoomOffsetX = 0;
                    ZoomOffsetY = 0;
                }
            }
            if (MapVersion > 10)
            {
                TacticalModeTempladeId = reader.ReadInt();
            }
            UseLowPassFilter = reader.ReadBoolean();
            UseReverb = reader.ReadBoolean();
            if (UseReverb)
                PresetId = reader.ReadInt();
            else
                PresetId = -1;

            BackgroundsCount = reader.ReadSByte();
            for (var i = 0; i < BackgroundsCount; i++)
            {
                var fixture = new Fixture();
                fixture.Init(reader);
                BackgroundFixtures.Add(fixture);
            }
            ForegroundsCount = reader.ReadSByte();
            for (var i = 0; i < ForegroundsCount; i++)
            {
                var fixture = new Fixture();
                fixture.Init(reader);
                ForegroundFixtures.Add(fixture);
            }
            reader.ReadInt();
            GroundCRC = reader.ReadInt().ToString();
            LayersCount = reader.ReadSByte();
            for (int i = 0; i < LayersCount; i++) 
            {
                var layer = new Layer();
                layer.Init(reader, MapVersion);
                Layers.Add(layer);
            }
            CellsCount = 560;
            for (int i = 0; i < CellsCount; i++) 
            {
                CellData cd = new CellData();
                cd.Init(reader, MapVersion, i, this);
                Cells.Add(cd);
            }
        }
    }
}