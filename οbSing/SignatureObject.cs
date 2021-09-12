using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Toolkit.HighPerformance;
using Utf8Json;
using Utf8Json.Resolvers;

namespace obSing
{
    public static class SignatureObject
    {
        public static int GetSignature(this Type type)
            => GetHashCode(Activator.CreateInstance(type, true));

        public static int GetSignature<T>(this T entity) where T : class
            => GetHashCode(entity);

        public static int GetSignature<T>() where T : new()
            => GetHashCode(new T());

        public static int GetSignature(this object obj)
            => GetHashCode(obj);

        private static int GetHashCode(object obj, IJsonFormatterResolver resolver = null)
        {
            JsonSerializer.SetDefaultResolver(resolver ?? StandardResolver.AllowPrivate);

            var depedencies = obj.GetCustomDependencies();

            var classJsonSerialization = new StringBuilder();

            foreach (var depedency in depedencies)
            {
                var sb = new StringBuilder(JsonSerializer.ToJsonString(Activator.CreateInstance(depedency.Type, true)));

                sb.AddTypesToPropertiesNames(depedency.PropertyInfos);

                classJsonSerialization.Append($"\"type\":\"{depedency.Name}\"");
                classJsonSerialization.Append(sb);
            }

            return classJsonSerialization.ToString().GetDjb2HashCode();
        }

        private static void AddTypesToPropertiesNames(this StringBuilder sb, List<PropertyInfo> propertyInfos)
        {
            foreach (var propertyInfo in propertyInfos)
            {
                var propertyInfoPresent = propertyInfo.ToString();
                var propertyName = propertyInfoPresent.Split(' ');
                if (propertyName.Length >= 2)
                    sb.Replace(propertyName[1], propertyInfoPresent);
            }
        }
    }
}
