namespace Cookie.Protocol.Enums
{
    public enum PlayerStatusEnum/*: uint*/
    {
        PLAYER_STATUS_OFFLINE = 0,
        PLAYER_STATUS_UNKNOWN = 1,
        PLAYER_STATUS_AVAILABLE = 10,
        PLAYER_STATUS_IDLE = 20,
        PLAYER_STATUS_AFK = 21,
        PLAYER_STATUS_PRIVATE = 30,
        PLAYER_STATUS_SOLO = 40
    }
}