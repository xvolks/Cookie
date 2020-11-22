namespace Cookie.Protocol.Enums
{
    public enum ServerStatusEnum/*: uint*/
    {
        STATUS_UNKNOWN = 0,
        OFFLINE = 1,
        STARTING = 2,
        ONLINE = 3,
        NOJOIN = 4,
        SAVING = 5,
        STOPING = 6,
        FULL = 7
    }
}