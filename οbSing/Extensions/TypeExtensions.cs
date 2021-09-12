using System;
using System.Collections;
using System.Linq;

namespace obSing.Extensions
{
    public static class TypeExtensions
    {
        private static readonly Type IEnumerableType = typeof(IEnumerable);
        private static readonly Type StringType = typeof(string);

        public static Type IEnumerableInnerCustomTypeArgument(this Type type)
            => type.GenericTypeArguments.FirstOrDefault(t => !t.IsIEnumerable() && !t.IsSystemType() && (t.IsClass || t.IsCustomValueType()));

        public static bool IsIEnumerable(this Type propertyType)
            => IEnumerableType.IsAssignableFrom(propertyType) && !StringType.IsAssignableFrom(propertyType);

        public static bool IsCustomValueType(this Type type)
            => type.IsValueType && !type.IsPrimitive && type.Namespace != null && !type.IsSystemType();

        public static bool IsCustomType(this Type type)
            => type.IsClass && !type.IsSystemType();

        public static bool IsSystemType(this Type type)
            => type.Namespace.StartsWith(nameof(System));
    }
}