using System;
using System.Collections.Generic;
using System.Reflection;

namespace obSing
{
    public class Dependency
    {
        public string Name { get; set; }
        public DependencyLevel Level { get; set; }
        public Type Type { get; set; }

        public List<PropertyInfo> PropertyInfos { get; set; }
    }

    public enum DependencyLevel
    {
        Instance = 0,
        Info = 5
    }
}
