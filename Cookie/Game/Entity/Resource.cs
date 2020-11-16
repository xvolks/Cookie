using Cookie.API.Game.Entity;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;

namespace Cookie.Game.Entity
{
    public class Resource : IResource, IEntity
    {
        public Resource(int cell, double id, int typeId)
        {
            CellId = cell;
            Id = id;
            TypeId = typeId;
        }

        public int CellId { get; set; }

        public double Id { get; set; }
        public int TypeId { get; set; }


        public string Name => FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<API.Datacenter.Skill>((uint)TypeId).NameId);

    }
}