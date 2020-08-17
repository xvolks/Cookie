using System;
using System.IO;
using System.Linq;
using System.Text;

//--+------------------------------------+--
//  |                                    |
//  |           The Falcon               |
//  |                                    |
//--+------------------------------------+--

namespace Cookie.API.Gamedata.D2i
{
    public class FastD2IReader : IDisposable
    {
        private static volatile FastD2IReader _instance;
        private static readonly object syncRoot = new object();

        private static bool _isFastLoad;

        //Gloabal Variables
        private static readonly FastD2I _myD2I = new FastD2I();

        private static string _pather;
        private static BinaryReader _br;
        private readonly Stream _stream;

        private FastD2IReader()
        {
        }

        public static FastD2IReader Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new FastD2IReader();
                }

                return _instance;
            }
        }

        /// <summary>
        ///     Handles the creation of new reader
        /// </summary>
        /// <param name="d2IPath">Path to the .d2i file</param>
        /// <param name="fastLoad">Enable the fast load, by default it's set to True.</param>
        /// <remarks></remarks>
        public void Init(string d2IPath, bool fastLoad = true)
        {
            //Assign fastload information so can be reused in GetText
            _isFastLoad = fastLoad;
            //Assign path information so can be reused in GetText
            _pather = d2IPath;
            //Slow loading if needed
            if (_isFastLoad == false)
                LoadD2I();
        }

        private static void LoadD2I()
        {
            using (_br = new BinaryReader(File.Open(_pather, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //Get the total size
                _myD2I.SizeOfD2I = _br.BaseStream.Length;
                //Get the data size
                _myD2I.SizeOfData = ReadInt();
                //Load the data
                while (_br.BaseStream.Position < _myD2I.SizeOfData)
                {
                    //Store the current data
                    var temp = new DataD2I
                    {
                        StrIndex = _br.BaseStream.Position,
                        StrSize = ReadShort()
                    };
                    temp.Str = ReadUtf8(temp.StrSize);
                    //Add the data to the list
                    _myD2I.DataList.Add(temp);
                }
                //Get indexes size
                _myD2I.SizeOfIndex = ReadInt();
                //Load indexes
                while (_br.BaseStream.Position - _myD2I.SizeOfData < _myD2I.SizeOfIndex)
                {
                    //Store the current read index
                    var temp = new Index
                    {
                        IStrKey = ReadInt(),
                        IDiaExist = ReadBool(),
                        IStrIndex = ReadInt()
                    };
                    //Check if Dia exists
                    if (temp.IDiaExist)
                        temp.IDiaIndex = ReadInt();
                    //Add it to the list
                    _myD2I.IndexList.Add(temp);
                }
                _br.Dispose();
                GC.Collect();
            }
        }

        /// <summary>
        ///     Fetch the text associated with the ID
        /// </summary>
        /// <param name="toSearch">ID of the text to get</param>
        /// <param name="versionDiacritique">Choose if you prefer the diacritical value or not, by default it's set to True.</param>
        /// <remarks></remarks>
        public string GetText<T>(T toSearch, bool versionDiacritique = false)
        {
            var myId = default(uint);
            var result = new DataD2I {Str = ""};
            if (typeof(T) == typeof(string))
            {
                myId = Convert.ToUInt32(toSearch);
            }
            else if (IsNumeric(toSearch.ToString()))
            {
                var convert = uint.TryParse(toSearch.ToString(), out myId);
            }
            if (_isFastLoad == false)
                try
                {
                    if (versionDiacritique)
                    {
                        uint pointer;
                        try
                        {
                            pointer = _myD2I.IndexList.First(n => (n.IStrKey == myId) & n.IDiaExist).IDiaIndex;
                        }
                        catch (Exception)
                        {
                            pointer = _myD2I.IndexList.First(n => n.IStrKey == myId).IStrIndex;
                        }

                        result.Str = _myD2I.DataList.First(m => m.StrIndex == pointer).Str;
                    }
                    else
                    {
                        var pointer = _myD2I.IndexList.First(n => n.IStrKey == myId).IStrIndex;
                        result.Str = _myD2I.DataList.First(m => m.StrIndex == pointer).Str;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            else
                using (_br = new BinaryReader(File.Open(_pather, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    _myD2I.SizeOfD2I = _br.BaseStream.Length;
                    _myD2I.SizeOfData = ReadInt();
                    _br.BaseStream.Position = _myD2I.SizeOfData;
                    _myD2I.SizeOfIndex = ReadInt();
                    try
                    {
                        while (_br.BaseStream.Position - _myD2I.SizeOfData < _myD2I.SizeOfIndex)
                        {
                            var temp = new Index();
                            var temp2 = ReadInt();
                            if (temp2 == myId)
                            {
                                temp.IStrKey = temp2;
                                temp.IDiaExist = ReadBool();
                                temp.IStrIndex = ReadInt();
                                if (temp.IDiaExist)
                                    temp.IDiaIndex = ReadInt();
                                var pointer = versionDiacritique ? temp.IDiaIndex : temp.IStrIndex;
                                _br.BaseStream.Position = pointer;
                                result.StrIndex = pointer;
                                result.StrSize = ReadShort();
                                result.Str = ReadUtf8(result.StrSize);
                                break; // TODO: might not be correct. Was : Exit While
                            }
                            temp.IDiaExist = ReadBool();
                            temp.IStrIndex = ReadInt();
                            if (temp.IDiaExist)
                                temp.IDiaIndex = ReadInt();
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            //Return the result
            return result.Str;
        }

        public string GetUi(string mySearch)
        {
            var uiResult = "No Result";
            using (_br = new BinaryReader(File.Open(_pather, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                _br.BaseStream.Position = 0;
                _myD2I.SizeOfD2I = _br.BaseStream.Length;
                _myD2I.SizeOfData = ReadInt();
                _br.BaseStream.Position = _myD2I.SizeOfData;
                _myD2I.SizeOfIndex = ReadInt();
                _br.BaseStream.Position = _br.BaseStream.Position + _myD2I.SizeOfIndex;
                _myD2I.SizeOfUi = ReadInt();
                try
                {
                    while (_br.BaseStream.Position < _br.BaseStream.Length)
                    {
                        var myUi = new UI {UStrIndex = ReadShort()};
                        myUi.UStr = ReadUtf8(myUi.UStrIndex);
                        myUi.UPointer = ReadInt();
                        if (string.Compare(mySearch, myUi.UStr, StringComparison.OrdinalIgnoreCase) != 0) continue;
                        _br.BaseStream.Position = myUi.UPointer;
                        var myResult = new DataD2I
                        {
                            StrIndex = myUi.UPointer,
                            StrSize = ReadShort()
                        };
                        myResult.Str = ReadUtf8(myResult.StrSize);
                        uiResult = myResult.Str;
                        break; // TODO: might not be correct. Was : Exit While
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return uiResult;
        }

        //Read 4 bytes to UInteger 32 (reversed for endian)
        private static uint ReadInt()
        {
            var int32 = _br.ReadBytes(4);
            int32 = int32.Reverse().ToArray();
            return BitConverter.ToUInt32(int32, 0);
        }

        //Read 2 bytes to UInteger 16 (reversed for endian)
        private static ushort ReadShort()
        {
            var myShort = _br.ReadBytes(2);
            myShort = myShort.Reverse().ToArray();
            return BitConverter.ToUInt16(myShort, 0);
        }

        //Read 1 byte for Boolean
        private static bool ReadBool()
        {
            var result = _br.ReadBoolean();
            return result;
        }

        //Read X bytes to UTF-8
        private static string ReadUtf8(ushort mySize)
        {
            var buffer = _br.ReadBytes(mySize);
            return Encoding.UTF8.GetString(buffer);
        }

        public bool IsNumeric(string input)
        {
            return int.TryParse(input, out var test);
        }


        #region "IDisposable Support"

        // To detect redundant calls
        private bool _disposedValue;

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                //Dispose reader on class dispose
                try
                {
                    _br.Dispose();
                }
                catch (Exception)
                {
                    // ignored
                }
                //Dispose stream on class dispose
                try
                {
                    _stream.Dispose();
                }
                catch (Exception)
                {
                    // ignored
                }
                // TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                // TODO: set large fields to null.
            }
            _disposedValue = true;
        }

        // TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        //Protected Overrides Sub Finalize()
        //    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        //    Dispose(False)
        //    MyBase.Finalize()
        //End Sub

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
            // TODO: uncomment the following line if Finalize() is overridden above.
            // GC.SuppressFinalize(Me)
        }

        #endregion
    }
}