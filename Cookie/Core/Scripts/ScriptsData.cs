using MoonSharp.Interpreter;

namespace Cookie.Core.Scripts
{
    [MoonSharpUserData]
    public class ScriptCharacter
    {
        public int LifePointsPercentage { get; set; }
    }

    [MoonSharpUserData]
    internal class ScriptEnemy
    {
        public int LifePointsPercentage { get; set; }
    }
}