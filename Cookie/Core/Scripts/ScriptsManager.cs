using System;
using System.Collections.Generic;
using System.IO;
using MoonSharp.Interpreter;

namespace Cookie.Core.Scripts
{
    public class ScriptsManager
    {
        public static List<IASpell> LoadSpellsFromIA(string path)
        {
            var spells = new List<IASpell>();

            var script = new Script();

            script.Globals["Character"] = new ScriptCharacter {LifePointsPercentage = 55};
            script.Globals["Enemy"] = new ScriptEnemy {LifePointsPercentage = 30};

            if (string.IsNullOrEmpty(path) ||
                !File.Exists(path))
                return null;

            script.DoFile(path);

            var test = script.Globals.Get("Spells");
            foreach (var elem in test.Table.Pairs)
            {
                int spellId = -1, relaunch = -1;
                var condition = true;
                var target = SpellTarget.Enemy;

                foreach (var pair in elem.Value.Table.Pairs)
                {
                    var key = pair.Key.ToString();
                    key = key.ToLower();
                    switch (key)
                    {
                        case "\"spell\"":
                            spellId = int.Parse(pair.Value.ToString());
                            break;
                        case "\"target\"":
                            var targettmp = pair.Value.ToString();
                            switch (targettmp.ToLower())
                            {
                                case "\"self\"":
                                    target = SpellTarget.Self;
                                    break;
                                case "\"enemy\"":
                                    target = SpellTarget.Enemy;
                                    break;
                                case "\"ally\"":
                                    target = SpellTarget.Ally;
                                    break;
                            }
                            break;
                        case "\"relaunchs\"":
                        case "\"relaunch\"":
                            relaunch = int.Parse(pair.Value.ToString());
                            break;
                        case "\"conditionfunc\"":
                            condition = pair.Value.CastToBool();
                            break;
                        default:
                            Console.WriteLine(@"Erreur: " + key);
                            break;
                    }
                }

                if (spellId != -1 && relaunch != -1)
                    spells.Add(new IASpell(spellId, relaunch, target, condition));
            }

            return spells;
        }
    }
}