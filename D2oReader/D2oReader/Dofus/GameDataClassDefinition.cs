using System.Collections.Generic;

namespace D2oReader
{
    public class GameDataClassDefinition
    {
        public string Name;
        public string PackageName;
        public List<GameDataField> Fields;

        public GameDataClassDefinition(string packageName,string className)
        {
            Fields = new List<GameDataField>();
            Name = className;
            PackageName = packageName;
        }

        internal void AddField(D2OReader reader)
        {
            GameDataField field = new GameDataField(reader);

            Fields.Add(field);
        }
    }
}