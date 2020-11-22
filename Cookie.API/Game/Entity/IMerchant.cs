namespace Cookie.API.Game.Entity
{
    public interface IMerchant : IEntity, IPlayer
    {
        byte SellType { get; }
    }
}