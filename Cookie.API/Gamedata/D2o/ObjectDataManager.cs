using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cookie.API.Utils.Extensions;

namespace Cookie.API.Gamedata.D2o
{
    public class ObjectDataManager : Singleton<ObjectDataManager>
    {
        private readonly List<Type> ignoredTypes = new List<Type>();
        private readonly Dictionary<Type, D2oReader> readers = new Dictionary<Type, D2oReader>();

        public void AddReaders(string directory)
        {
            foreach (var D2oFile in Directory.EnumerateFiles(directory).Where(entry => entry.EndsWith(".d2o")))
            {
                var reader = new D2oReader(D2oFile);

                AddReader(reader);
            }
        }

        private void AddReader(D2oReader D2oFile)
        {
            var classes = D2oFile.Classes;

            foreach (var @class in classes)
            {
                //if (ignoredTypes.Contains(@class.Value.ClassType))
                    //continue;

                // this classes are not bound to a single file, so we ignore them
                if (readers.ContainsKey(@class.Value.ClassType))
                {
                    /*
                    if(readers.TryGetValue(@class.Value.ClassType, out D2oReader existing))
                    {
                        Console.WriteLine($"{@class.Value.ClassType.Name}");
                        foreach (var item in D2oFile.Indexes)
                            existing.Indexes.Add(item.Key, item.Value);
                        throw new Exception("");
                    }*/
                    //ignoredTypes.Add(@class.Value.ClassType);
                    //readers.Remove(@class.Value.ClassType);
                }
                else
                {
                    readers.Add(@class.Value.ClassType, D2oFile);
                }
            }
        }

        public T Get<T>(uint key)
            where T : class
        {
            return Get<T>((int) key);
        }

        public T Get<T>(int key, bool noExceptionThrown = false)
            where T : class
        {
            if (!readers.ContainsKey(typeof(T))) // This exception should be called in all cases (serious)
                throw new ArgumentException("Cannot find data corresponding to type : " + typeof(T));

            var reader = readers[typeof(T)];

            return reader.ReadObject<T>(key, true, noExceptionThrown);
        }

        public T GetOrDefault<T>(uint key)
            where T : class
        {
            return GetOrDefault<T>((int) key);
        }

        public T GetOrDefault<T>(int key)
            where T : class
        {
            try
            {
                return Get<T>(key);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Type> GetAllTypes()
        {
            return readers.Keys;
        }

        public IEnumerable<T> EnumerateObjects<T>() where T : class
        {
            if (!readers.ContainsKey(typeof(T)))
                throw new ArgumentException("Cannot find data corresponding to type : " + typeof(T));

            var reader = readers[typeof(T)];

            return reader.Indexes.Select(index => reader.ReadObject(index.Key, true)).OfType<T>().Select(obj => obj);
        }
    }
}