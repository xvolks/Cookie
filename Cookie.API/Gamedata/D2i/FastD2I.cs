using System.Collections.Generic;

//--+------------------------------------+--
//  |                                    |
//  |           The Falcon               |
//  |                                    |
//--+------------------------------------+--
//Main holder of the data

namespace Cookie.API.Gamedata.D2i
{
    public class FastD2I
    {
        //Size of the whole file
        public long SizeOfD2I { get; set; }

        //Size of main data
        public uint SizeOfData { get; set; }

        //List of the data
        public List<DataD2I> DataList { get; set; }

        //Size of the indexes
        public uint SizeOfIndex { get; set; }

        //List of the indexes
        public List<Index> IndexList { get; set; }

        public uint SizeOfUi { get; set; }
    }

    public class DataD2I
    {
        //Index of the String
        public long StrIndex { get; set; }

        //Size of the String
        public ushort StrSize { get; set; }

        //The String itself
        public string Str { get; set; }
    }

    public class Index
    {
        //The Key of the string to find
        public uint IStrKey { get; set; }

        //The pointer to the string in the file
        public uint IStrIndex { get; set; }

        //Store if Diacritical exists
        public bool IDiaExist { get; set; }

        //Store its pointer if exists
        public uint IDiaIndex { get; set; }
    }

    public class UI
    {
        public ushort UStrIndex { get; set; }
        public string UStr { get; set; }
        public uint UPointer { get; set; }
    }
}