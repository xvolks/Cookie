using System;
using System.Collections.Generic;
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
        public string GroundCRC { get; set; }
        public int Id { get; set; }
        public bool IsUsingNewMovementSystem { get; set; }
        public List<Layer> Layers { get; set; }
        public int LayersCount { get; set; }
        public int LeftNeighbourId { get; set; }
        public int MapType { get; set; }
        public int MapVersion { get; set; }
        public int PresetId { get; set; }
        public int RelativeId { get; set; }
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
            reader.ReadSByte();
            MapVersion = reader.ReadSByte();
            Id = (int) reader.ReadUInt();

            if (MapVersion >= 7)
            {
                Encrypted = reader.ReadBoolean();
                EncryptedVersion = reader.ReadSByte();
                var count = reader.ReadInt();
                if (Encrypted)
                {
                    var buffer = CustomHex.ToArray(CustomHex.FromString("649ae451ca33ec53bbcbcc33becf15f4"));
                    var buffer2 = reader.ReadBytes(count);
                    for (var n = 0; n < buffer2.Length; n++)
                        buffer2[n] = Convert.ToByte(buffer2[n] ^ buffer[n % buffer.Length]);
                    reader = new BigEndianReader(buffer2);
                }
            }

            RelativeId = (int) reader.ReadUInt();
            MapType = reader.ReadSByte();
            SubAreaId = reader.ReadInt();
            TopNeighbourId = reader.ReadInt();
            BottomNeighbourId = reader.ReadInt();
            LeftNeighbourId = reader.ReadInt();
            RightNeighbourId = reader.ReadInt();
            ShadowBonusOnEntities = (int) reader.ReadUInt();

            if (MapVersion >= 9)
            {
                var readColor = reader.ReadInt();
                BackgroundAlpha = (readColor & 4278190080) >> 32;
                BackgroundRed = (readColor & 16711680) >> 16;
                BackgroundGreen = (readColor & 65280) >> 8;
                BackgroundBlue = readColor & 255;
                var readColor2 = reader.ReadUInt();
                GridAlpha = (readColor2 & 4278190080) >> 32;
                GridRed = (readColor2 & 16711680) >> 16;
                GridGreen = (readColor2 & 65280) >> 8;
                GridBlue = readColor2 & 255;
            }
            else if (MapVersion >= 3)
            {
                BackgroundRed = reader.ReadSByte();
                BackgroundGreen = reader.ReadSByte();
                BackgroundBlue = reader.ReadSByte();
            }
            if (MapVersion >= 4)
            {
                ZoomScale = Convert.ToDouble(reader.ReadUShort()) / 100;
                ZoomOffsetX = reader.ReadShort();
                ZoomOffsetY = reader.ReadShort();
            }

            UseLowPassFilter = reader.ReadBoolean();
            UseReverb = reader.ReadBoolean();
            if (UseReverb)
                PresetId = reader.ReadInt();
            BackgroundsCount = reader.ReadSByte();
            for (var i = 0; i < BackgroundsCount; i++)
            {
                var item = new Fixture();
                item.Init(reader);
                BackgroundFixtures.Add(item);
            }
            ForegroundsCount = reader.ReadSByte();
            for (var i = 0; i < ForegroundsCount; i++)
            {
                var fixture2 = new Fixture();
                fixture2.Init(reader);
                ForegroundFixtures.Add(fixture2);
            }
            CellsCount = 560;
            reader.ReadInt();
            GroundCRC = reader.ReadInt().ToString();
            LayersCount = reader.ReadSByte();
            for (var i = 0; i < LayersCount; i++)
            {
                var layer = new Layer();
                layer.Init(reader, MapVersion);
                Layers.Add(layer);
            }
            uint oldMvtSys = 0;
            for (var i = 0; i < CellsCount; i++)
            {
                var data = new CellData();
                data.Init(reader, MapVersion);
                if (oldMvtSys == 0)
                    oldMvtSys = data.MoveZone;
                if (data.MoveZone != oldMvtSys)
                    IsUsingNewMovementSystem = true;
                Cells.Add(data);
            }
        }
    }
}