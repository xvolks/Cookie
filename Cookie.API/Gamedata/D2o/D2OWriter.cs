#region License GNU GPL

// D2oWriter.cs
// 
// Copyright (C) 2012 - BehaviorIsManaged
// 
// This program is free software; you can redistribute it and/or modify it 
// under the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details. 
// You should have received a copy of the GNU General Public License along with this program; 
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cookie.API.Utils.IO;

namespace Cookie.API.Gamedata.D2o
{
    public class D2oWriter : IDisposable
    {
        private const int NullIdentifier = unchecked((int) 0xAAAAAAAA);

        private readonly object writingSync = new object();
        private Dictionary<Type, int> allocatedClassId = new Dictionary<Type, int>();

        private Dictionary<int, D2oClassDefinition> classes;
        private Dictionary<int, int> indexTable;
        private bool needToBeSync;
        private Dictionary<int, object> objects = new Dictionary<int, object>();
        private BigEndianWriter writer;
        private bool writing;

        /// <summary>
        ///     Create a new instance of D2oWriter
        /// </summary>
        /// <param name="filename"></param>
        public D2oWriter(string filename)
        {
            Filename = filename;

            if (!File.Exists(filename))
                CreateWrite(filename);
            else
                OpenWrite();
        }

        public string BakFilename { get; set; }

        public string Filename { get; set; }

        public void Dispose()
        {
            if (writing)
                EndWriting();
        }

        /// <summary>
        ///     Create and flush and empty D2o file
        /// </summary>
        /// <param name="path"></param>
        public static void CreateEmptyFile(string path)
        {
            if (File.Exists(path))
                throw new Exception("File already exists, delete before overwrite");

            var writer = new BinaryWriter(File.OpenWrite(path));

            writer.Write("D2o");
            writer.Write((int) writer.BaseStream.Position + 4); // index table offset

            writer.Write(0); // index table len
            writer.Write(0); // class count

            writer.Flush();
            writer.Close();
        }

        private void CreateWrite(string filename)
        {
            writer = new BigEndianWriter(File.Create(filename));

            indexTable = new Dictionary<int, int>();
            classes = new Dictionary<int, D2oClassDefinition>();
            objects = new Dictionary<int, object>();
            allocatedClassId = new Dictionary<Type, int>();
        }

        private void OpenWrite()
        {
            writer = new BigEndianWriter(File.OpenWrite(Filename));

            ResetMembersByReading();
        }

        private void ResetMembersByReading()
        {
            var reader = new D2oReader(File.OpenRead(Filename));

            indexTable = reader.Indexes;
            classes = reader.Classes;
            allocatedClassId = classes.ToDictionary(entry => entry.Value.ClassType, entry => entry.Key);
            objects = reader.ReadObjects();

            reader.Close();
        }

        /// <summary>
        ///     Start editing of the D2o file
        /// </summary>
        /// <param name="backupFile"></param>
        public void StartWriting(bool backupFile = true)
        {
            if (backupFile)
            {
                BakFilename = Filename + ".bak";
                File.Copy(Filename, BakFilename, true);
            }

            // overwrite existing file
            File.WriteAllBytes(Filename, new byte[0]);

            writing = true;
            lock (writingSync)
            {
                if (needToBeSync)
                    ResetMembersByReading();
            }
        }

        /// <summary>
        ///     Stop editing the D2o file, flush the file and dispose ressources
        /// </summary>
        public void EndWriting()
        {
            lock (writingSync)
            {
                writer.Seek(0, SeekOrigin.Begin);

                writing = false;
                needToBeSync = false;

                WriteHeader();

                foreach (var obj in objects)
                {
                    if (!indexTable.ContainsKey(obj.Key))
                        indexTable.Add(obj.Key, (int) writer.BaseStream.Position);
                    else
                        indexTable[obj.Key] = (int) writer.BaseStream.Position;

                    WriteObject(obj.Value, obj.Value.GetType());
                }

                WriteIndexTable();
                WriteClassesDefinition();

                writer.Dispose();
            }
        }


        private void WriteHeader()
        {
            writer.WriteUTFBytes("D2o");
            writer.WriteInt(0); // allocate space to write the correct index table offset
        }

        private void WriteIndexTable()
        {
            var offset = (int) writer.BaseStream.Position;

            writer.Seek(3, SeekOrigin.Begin);
            writer.WriteInt(offset);

            writer.Seek(offset, SeekOrigin.Begin);
            writer.WriteInt(indexTable.Count * 8);

            foreach (var index in indexTable)
            {
                writer.WriteInt(index.Key);
                writer.WriteInt(index.Value);
            }
        }

        private void WriteClassesDefinition()
        {
            writer.WriteInt(classes.Count);

            foreach (var classDefinition in classes.Values)
            {
                classDefinition.Offset = (int) writer.BaseStream.Position;
                writer.WriteInt(classDefinition.Id);

                writer.WriteUTF(classDefinition.Name);
                writer.WriteUTF(classDefinition.PackageName);

                writer.WriteInt(classDefinition.Fields.Count);

                foreach (var field in classDefinition.Fields.Values)
                {
                    field.Offset = (int) writer.BaseStream.Position;
                    writer.WriteUTF(field.Name);
                    writer.WriteInt((int) field.TypeId);

                    foreach (var vectorType in field.VectorTypes)
                    {
                        writer.WriteUTF(vectorType.Item2);
                        writer.WriteInt((int) vectorType.Item1);
                    }
                }
            }
        }

        public void Write<T>(T obj)
        {
            Write(obj, objects.Count > 0 ? objects.Keys.Max() + 1 : 0);
        }

        public void Write<T>(T obj, int index)
        {
            if (!writing)
                StartWriting();

            lock (writingSync)
            {
                needToBeSync = true;

                if (!IsClassDeclared(typeof(T)))
                    // if the class is not allocated then the class is not defined
                    DefineClassDefinition(typeof(T));

                if (objects.ContainsKey(index))
                    objects[index] = obj;
                else
                    objects.Add(index, obj);
            }
        }

        public void Delete(int index)
        {
            lock (writingSync)
            {
                if (objects.ContainsKey(index))
                    objects.Remove(index);
            }
        }

        private bool IsClassDeclared(Type classType)
        {
            return allocatedClassId.ContainsKey(classType);
        }

        private int AllocateClassId(Type classType)
        {
            var id = allocatedClassId.Count > 0 ? allocatedClassId.Values.Max() + 1 : 0;
            AllocateClassId(classType, id);

            return id;
        }

        private void AllocateClassId(Type classType, int classId)
        {
            allocatedClassId.Add(classType, classId);
        }

        private void DefineClassDefinition(Type classType)
        {
            if (classes.Count(entry => entry.Value.ClassType == classType) > 0) // already define
                return;

            AllocateClassId(classType);

            var attributes = classType.GetCustomAttributes(typeof(D2oClassAttribute), false);

            if (attributes.Length != 1)
                throw new Exception("The given class has no D2oClassAttribute attribute and cannot be wrote");

            var package = ((D2oClassAttribute) attributes[0]).PackageName;
            var name = !string.IsNullOrEmpty(((D2oClassAttribute) attributes[0]).Name)
                ? ((D2oClassAttribute) attributes[0]).Name
                : classType.Name;

            // add fields
            var fields = from field in classType.GetFields()
                let attribute = (D2oFieldAttribute) field.GetCustomAttributes(typeof(D2oFieldAttribute), false)
                    .SingleOrDefault()
                let fieldTypeId = GetIdByType(field.FieldType)
                let vectorTypes = GetVectorTypes(field.FieldType)
                let fieldName = attribute != null ? attribute.FieldName : field.Name
                where field.GetCustomAttributes(typeof(D2oIgnore), false).Count() <= 0
                select new D2oFieldDefinition(fieldName, fieldTypeId, field, -1, vectorTypes);

            // add properties
            fields.Concat(from property in classType.GetProperties()
                let attribute = (D2oFieldAttribute) property.GetCustomAttributes(typeof(D2oFieldAttribute), false)
                    .SingleOrDefault()
                let fieldTypeId = GetIdByType(property.PropertyType)
                let vectorTypes = GetVectorTypes(property.PropertyType)
                let fieldName = attribute != null ? attribute.FieldName : property.Name
                where property.GetCustomAttributes(typeof(D2oIgnore), false).Count() <= 0
                select new D2oFieldDefinition(fieldName, fieldTypeId, property, -1, vectorTypes));

            classes.Add(allocatedClassId[classType],
                new D2oClassDefinition(allocatedClassId[classType], name, package, classType, fields, -1));

            DefineAllocatedTypes(); // build class definition of allocated types that aren't define
        }

        private void DefineAllocatedTypes()
        {
            foreach (var allocatedClass in allocatedClassId.Where(entry => !classes.ContainsKey(entry.Value)))
                DefineClassDefinition(allocatedClass.Key);
        }

        private D2oFieldType GetIdByType(Type fieldType)
        {
            if (fieldType == typeof(int))
                return D2oFieldType.Int;
            if (fieldType == typeof(bool))
                return D2oFieldType.Bool;
            if (fieldType == typeof(string))
                return D2oFieldType.String;
            if (fieldType == typeof(double))
                return D2oFieldType.Double;
            if (fieldType == typeof(int)) // that's useless, i know ...
                return D2oFieldType.I18N;
            if (fieldType == typeof(uint))
                return D2oFieldType.UInt;
            if (fieldType.GetGenericTypeDefinition() == typeof(List<>))
                return D2oFieldType.List;

            int classId;
            if (allocatedClassId.ContainsKey(fieldType))
            {
                classId = AllocateClassId(fieldType);

                allocatedClassId.Add(fieldType, classId);
            }

            classId = allocatedClassId[fieldType];

            return (D2oFieldType) classId;
        }

        private Tuple<D2oFieldType, string>[] GetVectorTypes(Type vectorType)
        {
            var ids = new List<Tuple<D2oFieldType, string>>();

            if (vectorType.IsGenericType)
            {
                var currentGenericType = vectorType;
                var genericArguments = currentGenericType.GetGenericArguments();

                while (genericArguments.Length > 0)
                {
                    ids.Add(Tuple.Create(GetIdByType(genericArguments[0]), genericArguments[0].Name));

                    currentGenericType = genericArguments[0];
                    genericArguments = currentGenericType.GetGenericArguments();
                }
            }

            return ids.ToArray();
        }

        private void WriteObject(object obj, Type type)
        {
            if (!allocatedClassId.ContainsKey(obj.GetType()))
                throw new Exception(string.Format("Unexpected object of type {0} (was not registered)", obj.GetType()));

            var @class = classes[allocatedClassId[type]];

            writer.WriteInt(@class.Id);

            foreach (var field in @class.Fields)
            {
                var fieldValue = field.Value.GetValue(obj);

                WriteField(writer, field.Value, fieldValue);
            }
        }

        private void WriteField(IDataWriter writer, D2oFieldDefinition field, dynamic obj, int vectorDimension = 0)
        {
            switch (field.TypeId)
            {
                case D2oFieldType.Int:
                    WriteFieldInt(writer, (int) obj);
                    break;
                case D2oFieldType.Bool:
                    WriteFieldBool(writer, obj);
                    break;
                case D2oFieldType.String:
                    WriteFieldUTF(writer, obj);
                    break;
                case D2oFieldType.Double:
                    WriteFieldDouble(writer, obj);
                    break;
                case D2oFieldType.I18N:
                    WriteFieldI18n(writer, obj);
                    break;
                case D2oFieldType.UInt:
                    WriteFieldUInt(writer, (uint) obj);
                    break;
                case D2oFieldType.List:
                    WriteFieldVector(writer, field, obj, vectorDimension);
                    break;
                default:
                    WriteFieldObject(writer, obj);
                    break;
            }
        }


        private void WriteFieldVector(IDataWriter writer, D2oFieldDefinition field, IList list, int vectorDimension)
        {
            writer.WriteInt(list.Count);

            for (var i = 0; i < list.Count; i++)
                WriteField(writer, field, field.VectorTypes[vectorDimension], ++vectorDimension);
        }

        private void WriteFieldObject(IDataWriter writer, object obj)
        {
            if (obj == null)
            {
                writer.WriteInt(NullIdentifier);
            }
            else
            {
                if (!allocatedClassId.ContainsKey(obj.GetType()))
                    throw new Exception(string.Format("Unexpected object of type {0} (was not registered)",
                        obj.GetType()));

                var classid = allocatedClassId[obj.GetType()];
                writer.WriteInt(classid);

                WriteObject(obj, obj.GetType());
            }
        }

        private static void WriteFieldInt(IDataWriter writer, int value)
        {
            writer.WriteInt(value);
        }

        private static void WriteFieldUInt(IDataWriter writer, uint value)
        {
            writer.WriteUInt(value);
        }

        private static void WriteFieldBool(IDataWriter writer, bool value)
        {
            writer.WriteBoolean(value);
        }

        private static void WriteFieldUTF(IDataWriter writer, string value)
        {
            writer.WriteUTF(value);
        }

        private static void WriteFieldDouble(IDataWriter writer, double value)
        {
            writer.WriteDouble(value);
        }

        private static void WriteFieldI18n(IDataWriter writer, int value)
        {
            writer.WriteInt(value);
        }
    }
}