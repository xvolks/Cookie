using System.Collections.Generic;

namespace Cookie.API.Gamedata.D2p
{
    /// <summary>
    ///     Represents some extra data of the current map
    /// </summary>
    public interface IMap
    {
        long BackgroundAlpha { get; set; }

        int BackgroundBlue { get; set; }
        List<Fixture> BackgroundFixtures { get; set; }
        int BackgroundGreen { get; set; }
        int BackgroundRed { get; set; }
        int BackgroundsCount { get; set; }
        int BottomNeighbourId { get; set; }
        bool Encrypted { get; set; }
        int EncryptedVersion { get; set; }
        List<Fixture> ForegroundFixtures { get; set; }
        int ForegroundsCount { get; set; }
        uint GridAlpha { get; set; }
        uint GridBlue { get; set; }
        uint GridGreen { get; set; }
        uint GridRed { get; set; }
        string GroundCRC { get; set; }
        int Id { get; set; }
        bool IsUsingNewMovementSystem { get; set; }
        List<Layer> Layers { get; set; }
        int LayersCount { get; set; }
        int LeftNeighbourId { get; set; }
        int MapType { get; set; }
        int MapVersion { get; set; }
        int PresetId { get; set; }
        int RelativeId { get; set; }
        int RightNeighbourId { get; set; }
        int ShadowBonusOnEntities { get; set; }
        int SubAreaId { get; set; }
        int TopNeighbourId { get; set; }
        bool UseLowPassFilter { get; set; }
        bool UseReverb { get; set; }
        int ZoomOffsetX { get; set; }
        int ZoomOffsetY { get; set; }
        double ZoomScale { get; set; }

        /// <summary>
        ///     Gets the list of cells in the current map
        /// </summary>
        List<CellData> Cells { get; }

        /// <summary>
        ///     Gets the cells count in the current map
        /// </summary>
        int CellsCount { get; }
    }
}