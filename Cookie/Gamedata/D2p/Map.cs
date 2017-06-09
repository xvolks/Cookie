using Cookie;
using Cookie.IO;
using System;
using System.Collections.Generic;

namespace Cookie.Gamedata.D2p
{

    public class Map : IMap
    {

        public List<CellData> Cells
        {
            get { return cells; }
        }

        public bool IsLineOfSight(int cellId)
        {
            return (((cellId >= 0) && (cellId < CellsCount)) && cells[cellId].Los);
        }

        public bool IsWalkable(int cellId)
        {
            return (((cellId >= 0) && (cellId < CellsCount)) && cells[cellId].Mov);
        }

        internal void Init(BigEndianReader reader)
        {
            reader.ReadSByte();
            MapVersion = reader.ReadSByte();
            Id = (int)reader.ReadUInt();

            if (MapVersion >= 7)
            {
                Encrypted = reader.ReadBoolean();
                EncryptedVersion = reader.ReadSByte();
                int count = reader.ReadInt();
                if (Encrypted)
                {
                    byte[] buffer = CustomHex.ToArray(CustomHex.FromString("649ae451ca33ec53bbcbcc33becf15f4", false));
                    byte[] buffer2 = reader.ReadBytes(count);
                    for (int n = 0; n < buffer2.Length; n++)
                        buffer2[n] = Convert.ToByte((buffer2[n] ^ buffer[(n % buffer.Length)]));
                    reader = new BigEndianReader(buffer2);
                }
            }

            RelativeId = (int)reader.ReadUInt();
            MapType = reader.ReadSByte();
            SubAreaId = reader.ReadInt();
            TopNeighbourId = reader.ReadInt();
            BottomNeighbourId = reader.ReadInt();
            LeftNeighbourId = reader.ReadInt();
            RightNeighbourId = reader.ReadInt();
            ShadowBonusOnEntities = (int)reader.ReadUInt();

            if (MapVersion >= 9)
            {
                int readColor = reader.ReadInt();
                BackgroundAlpha = (readColor & 4278190080) >> 32;
                BackgroundRed = (readColor & 16711680) >> 16;
                BackgroundGreen = (readColor & 65280) >> 8;
                BackgroundBlue = readColor & 255;
                uint readColor2 = reader.ReadUInt();
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
            for (int i = 0; i < BackgroundsCount; i++)
            {
                Fixture item = new Fixture();
                item.Init(reader);
                BackgroundFixtures.Add(item);
            }
            ForegroundsCount = reader.ReadSByte();
            for (int i = 0; i < ForegroundsCount; i++)
            {
                Fixture fixture2 = new Fixture();
                fixture2.Init(reader);
                ForegroundFixtures.Add(fixture2);
            }
            CellsCount = 560;
            reader.ReadInt();
            GroundCRC = reader.ReadInt().ToString();
            LayersCount = reader.ReadSByte();
            for (int i = 0; i < LayersCount; i++)
            {
                Layer layer = new Layer();
                layer.Init(reader, MapVersion);
                Layers.Add(layer);
            }
            uint oldMvtSys = 0;
            for (int i = 0; i < CellsCount; i++)
            {
                CellData data = new CellData();
                data.Init(reader, MapVersion);
                if (oldMvtSys == 0)
                    oldMvtSys = data.MoveZone;
                if (data.MoveZone != oldMvtSys)
                    IsUsingNewMovementSystem = true;
                cells.Add(data);
            }
        }

        // Fields
        public long BackgroundAlpha;
        public int BackgroundBlue;
        public List<Fixture> BackgroundFixtures = new List<Fixture>();
        public int BackgroundGreen;
        public int BackgroundRed;
        public int BackgroundsCount;
        public int BottomNeighbourId;
        public List<CellData> cells = new List<CellData>();
        public int CellsCount { get; private set; }
        public bool Encrypted;
        public int EncryptedVersion;
        public List<Fixture> ForegroundFixtures = new List<Fixture>();
        public int ForegroundsCount;
        public string GroundCRC;
        public int Id;
        public bool IsUsingNewMovementSystem;
        public List<Layer> Layers = new List<Layer>();
        public int LayersCount;
        public int LeftNeighbourId;
        public int MapType;
        public int MapVersion;
        public int PresetId;
        public int RelativeId;
        public int RightNeighbourId;
        public int ShadowBonusOnEntities;
        public int SubAreaId;
        public int TopNeighbourId;
        public bool UseLowPassFilter;
        public bool UseReverb;
        public int ZoomOffsetX;
        public int ZoomOffsetY;
        public double ZoomScale;
        public uint GridAlpha;
        public uint GridRed;
        public uint GridBlue;
        public uint GridGreen;
    }
}
