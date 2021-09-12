using obSing;
using obSing.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class DependencyValidator
{
    public static List<Dependency> GetCustomDependencies<TEntity>(this TEntity entity, List<Type> excludeTypes = null)
        where TEntity : class
    {
        var dependents = new List<Dependency>();

        if (entity == null)
            return dependents;

        var entityType = entity.GetType();

       entityType.UpdateExcludeTypes(ref excludeTypes);

        var propertyInfos = entityType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        if (!dependents.Any(x => x.Name == entityType.FullName))
            dependents.Add(new Dependency
            {
                Name = entityType.FullName,
                Level = DependencyLevel.Info,
                Type = entityType,
                PropertyInfos = propertyInfos.ToList()
            });

        var innerCustomTypes = propertyInfos
            .Where(p => !excludeTypes.Contains(p.PropertyType))
            .Select(s => s.PropertyType)
            .GetCustomClassesAndStructs(ref excludeTypes);

        foreach (var innerCustomType in innerCustomTypes)
        {
            if (innerCustomType.IsCustomType())
                dependents.AddRange(GetCustomDependencies(Activator.CreateInstance(innerCustomType, true), excludeTypes));

            if (innerCustomType.IsCustomType() && !dependents.Any(x => x.Name == innerCustomType.FullName))
                dependents.Add(new Dependency
                {
                    Name = innerCustomType.FullName,
                    Level = DependencyLevel.Instance,
                    Type = innerCustomType,
                    PropertyInfos = propertyInfos.ToList()
                });
            else
                dependents.FirstOrDefault(x => x.Name == innerCustomType.FullName).Level = DependencyLevel.Instance;
        }

        return dependents;
    }

    private static void UpdateExcludeTypes(this Type entityType, ref List<Type> excludeTypes)
    {
        if (excludeTypes != null)
            excludeTypes.Add(entityType);
        else
            excludeTypes = new List<Type> { entityType };
    }

    private static IEnumerable<Type> GetCustomClassesAndStructs(this IEnumerable<Type> types, ref List<Type> excludeTypes)
    {
        var customeTypes = new List<Type>();

        customeTypes.AddRange(types.Except(excludeTypes.Distinct()).Where(p => !p.IsSystemType() && (p.IsClass || p.IsCustomValueType())));

        if (customeTypes != null)
            excludeTypes.AddRange(customeTypes);

        var ennumerableTypes = types.Where(p => p.IsIEnumerable()).ToList();

        var innerTypes = new List<Type>();

        foreach (var ennumerableType in ennumerableTypes)
        {
            innerTypes.AddRange(ennumerableType.GenericInnerCustomTypeArguments(ref excludeTypes));
        }

        customeTypes.AddRange(innerTypes);

        return customeTypes;
    }

    private static IEnumerable<Type> GenericInnerCustomTypeArguments(this Type ennumerableType, ref List<Type> excludeTypes)
    {
        var types = new List<Type>();

        var innerGenericTypeArguments = ennumerableType.GenericTypeArguments
            .Except(excludeTypes.Distinct())
            .Where(t => t.IsClass || t.IsCustomValueType()).ToList();

        foreach (var innerGenericTypeArgument in innerGenericTypeArguments)
        {
            if (innerGenericTypeArgument.GenericTypeArguments.Any())
            {
                var innerTypes = innerGenericTypeArgument.GenericTypeArguments.Except(excludeTypes.Distinct());

                foreach (var innerType in innerTypes)
                {
                    if (!innerType.IsIEnumerable() && (innerType.IsClass || innerType.IsCustomValueType()))
                    {
                        types.Add(innerType);
                        excludeTypes.Add(innerType);
                    }

                    else if (innerType.IsIEnumerable())
                    {
                        types.AddRange(innerType.GenericInnerCustomTypeArguments(ref excludeTypes));
                    }
                }
            }
            else if (!innerGenericTypeArgument.IsIEnumerable() && innerGenericTypeArgument.IsCustomValueType())
            {
                types.Add(innerGenericTypeArgument);
            }
        }

        return types;
    }
}