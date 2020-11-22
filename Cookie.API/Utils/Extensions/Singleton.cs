﻿using System;
using System.Reflection;

namespace Cookie.API.Utils.Extensions
{
    public abstract class Singleton<T> where T : class
    {
        private static readonly object syncRoot = new object();

        /// <summary>
        ///     Returns the singleton instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                lock (syncRoot)
                {
                    return SingletonAllocator.instance;
                }
            }
            protected set => SingletonAllocator.instance = value;
        }

        #region Nested type: SingletonAllocator

        internal static class SingletonAllocator
        {
            internal static T instance;

            static SingletonAllocator()
            {
                CreateInstance(typeof(T));
            }

            public static T CreateInstance(Type type)
            {
                var ctorsPublic = type.GetConstructors(
                    BindingFlags.Instance | BindingFlags.Public);

                if (ctorsPublic.Length > 0)
                    return instance = (T) Activator.CreateInstance(type);

                var ctorNonPublic = type.GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, new ParameterModifier[0]);

                if (ctorNonPublic == null)
                    throw new Exception(
                        type.FullName +
                        " doesn't have a private/protected constructor so the property cannot be enforced.");

                try
                {
                    return instance = (T) ctorNonPublic.Invoke(new object[0]);
                }
                catch (Exception e)
                {
                    throw new Exception(
                        "The Singleton couldnt be constructed, check if " + type.FullName +
                        " has a default constructor",
                        e);
                }
            }
        }

        #endregion
    }
}