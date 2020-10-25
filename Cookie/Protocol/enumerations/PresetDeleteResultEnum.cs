namespace Cookie.Protocol.Enums
{
    public enum PresetDeleteResultEnum/*: uint*/
    {
        PRESET_DEL_OK = 1,
        PRESET_DEL_ERR_UNKNOWN = 2,
        PRESET_DEL_ERR_BAD_PRESET_ID = 3,
        PRESET_DEL_ERR_SYSTEM_INACTIVE = 4
    }
}