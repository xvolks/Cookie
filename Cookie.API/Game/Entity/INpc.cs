namespace Cookie.API.Game.Entity
{
    public interface INpc : IEntity
    {
        int NpcId { get; }
        string Name { get; }
    }
}