using Cookie.API.Protocol.Enums;

namespace Cookie.API.Utils
{
    public static class GameConstant
    {
        public const sbyte Major = 2;
        public const sbyte Minor = 51;
        public const sbyte Release = 5;
        public const int Revision = 74014085;
        public const sbyte Patch = 0;
        public const sbyte BuildType = (sbyte) BuildTypeEnum.RELEASE;
        public const sbyte Install = (sbyte) ClientInstallTypeEnum.CLIENT_BUNDLE;
        public const sbyte Technology = (sbyte) ClientTechnologyEnum.CLIENT_AIR;
    }
}