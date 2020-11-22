namespace Cookie.Protocol.Enums
{
    public enum TreasureHuntRequestEnum/*: uint*/
    {
        TREASURE_HUNT_ERROR_UNDEFINED = 0,
        TREASURE_HUNT_OK = 1,
        TREASURE_HUNT_ERROR_NO_QUEST_FOUND = 2,
        TREASURE_HUNT_ERROR_ALREADY_HAVE_QUEST = 3,
        TREASURE_HUNT_ERROR_NOT_AVAILABLE = 4,
        TREASURE_HUNT_ERROR_DAILY_LIMIT_EXCEEDED = 5
    }
}