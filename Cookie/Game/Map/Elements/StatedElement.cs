using Cookie.API.Game.Map.Elements;

namespace Cookie.Game.Map.Elements
{
    public class StatedElement : IStatedElement
    {
        public StatedElement(uint cellId, uint id, uint state)
        {
            CellId = cellId;
            Id = id;
            State = state;
        }

        public uint CellId { get; private set; }
        public uint Id { get; private set; }
        public uint State { get; private set; }
    }
}