namespace Cookie.Protocol.Enums
{
    public enum GameHierarchyEnum/*: int*/
    {
        UNAVAILABLE = -1,
        PLAYER = 0,
        MODERATOR = 10,
        GAMEMASTER_PADAWAN = 20,
        GAMEMASTER = 30,
        ADMIN = 40,
        UNKNOWN_SPECIAL_USER = 50
    }
}