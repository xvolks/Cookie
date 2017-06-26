using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cookie.API.Utils.Extensions
{
    public static class ReflectionExtensions
    {
        public static Type GetActionType(this MethodInfo method)
        {
            return Expression.GetActionType(method.GetParameters().Select(entry => entry.ParameterType).ToArray());
        }

        private static bool FilterByName(Type typeObj, object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }

        public static Delegate CreateDelegate(this ConstructorInfo ctor)
        {
            var list = (
                from param in ctor.GetParameters()
                select Expression.Parameter(param.ParameterType)).ToList();
            var lambdaExpression = Expression.Lambda(Expression.New(ctor, list), list);
            return lambdaExpression.Compile();
        }

        public static bool HasInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().FindInterfaces(FilterByName, interfaceType).Length > 0;
        }

        public static T[] GetCustomAttributes<T>(this ICustomAttributeProvider type)
            where T : Attribute
        {
            var attribs = type.GetCustomAttributes(typeof(T), false) as T[];
            return attribs;
        }

        public static T GetCustomAttribute<T>(this ICustomAttributeProvider type)
            where T : Attribute
        {
            return type.GetCustomAttributes<T>().FirstOrDefault();
        }

        public static bool IsDerivedFromGenericType(this Type type, Type genericType)
        {
            if (type == typeof(object))
                return false;

            if (type == null)
                return false;

            if (type.IsConstructedGenericType && type.GetGenericTypeDefinition() == genericType)
                return true;

            return IsDerivedFromGenericType(type.DeclaringType, genericType);
        }

        public static T CreateDelegate<T>(this ConstructorInfo ctor)
        {
            var parameters = ctor.GetParameters().Select(param => Expression.Parameter(param.ParameterType)).ToList();

            var lamba = Expression.Lambda<T>(Expression.New(ctor, parameters), parameters);

            return lamba.Compile();
        }
    }
}