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
        private readonly Dictionary<Type, List<D2oReader>> readers = new Dictionary<Type, List<D2oReader>>();

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

                // readers exists then we justa add then to the list of readers. If not then new List
                if (readers.ContainsKey(@class.Value.ClassType))
                    readers[@class.Value.ClassType].Add(D2oFile);
                else
                {
                    var tmp = new List<D2oReader>();
                    tmp.Add(D2oFile);
                    readers.Add(@class.Value.ClassType, tmp);
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

            var lReader = readers[typeof(T)];
            if(lReader.Count == 1)
                return lReader[0].ReadObject<T>(key, out bool isValid, true, noExceptionThrown);
            else
            {
                foreach(var reader in lReader)
                {
                    dynamic retReader = reader.ReadObject<T>(key, out bool isValid, true, true);
                        if (isValid)
                            return retReader;
                }
            }
            throw new ArgumentException($"Cannot find key corresponding to type : {key}");
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
            if(reader.Count == 1)
                return reader[0].Indexes.Select(index => reader[0].ReadObject(index.Key, true)).OfType<T>().Select(obj => obj);
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}