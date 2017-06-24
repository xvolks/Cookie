using Cookie.API.Protocol.Enums;

namespace Cookie.Utils
{
    public static class GameConstant
    {
        public const sbyte Major = 2;
        public const sbyte Minor = 42;
        public const sbyte Release = 0;
        public const int Revision = 121463;
        public const sbyte Patch = 6;
        public const sbyte BuildType = (sbyte) BuildTypeEnum.RELEASE;
        public const sbyte Install = (sbyte) ClientInstallTypeEnum.CLIENT_BUNDLE;
        public const sbyte Technology = (sbyte) ClientTechnologyEnum.CLIENT_AIR;
    }
}