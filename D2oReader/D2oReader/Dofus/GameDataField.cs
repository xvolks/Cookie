namespace D2oReader
{
    public class GameDataField
    {
        public  string fieldName;   
        public GameDataTypeEnum fieldType;  
        public GameDataField innerField;

        public GameDataField(D2OReader reader)
        {
            fieldName = reader.ReadUtf8();

            readType(reader);
        }

        public void readType(D2OReader reader)
        {
            GameDataTypeEnum fieldType = (GameDataTypeEnum)reader.ReadInt();
            this.fieldType = fieldType;

            if (fieldType == GameDataTypeEnum.Vector)
            {
                innerField = new GameDataField(reader);
            }
        }
    }
}