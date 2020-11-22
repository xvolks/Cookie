namespace Cookie.API.Game.Entity
{
    public interface IResource : IEntity
    {
        string Name { get; }
        int TypeId { get; }
    }
}