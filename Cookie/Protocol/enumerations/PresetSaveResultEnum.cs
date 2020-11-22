namespace Cookie.Protocol.Enums
{
    public enum PresetSaveResultEnum/*: uint*/
    {
        PRESET_SAVE_OK = 1,
        PRESET_SAVE_ERR_UNKNOWN = 2,
        PRESET_SAVE_ERR_TOO_MANY = 3,
        PRESET_SAVE_ERR_INVALID_PLAYER_STATE = 4,
        PRESET_SAVE_ERR_SYSTEM_INACTIVE = 5,
        PRESET_SAVE_ERR_INVALID_ID = 6
    }
}