using FluentAssertions;
using obSing;
using obSingTests.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace obSingTests.DependenciesTests
{
    public class DependenciesTests
    {
        [Fact]
        public void Given_Class1_When_Get_Depedencies_Then_3_Dependencies_Return()
        {
            //Arrange
            var myClass1Types = Activator.CreateInstance(typeof(Class1), true);
            var depedencies = new List<Dependency>
            {
                new Dependency { Name = "obSingTests.Classes.Class1", Type = typeof(Class1), Level = DependencyLevel.Info },
                new Dependency { Name = "obSingTests.Classes.Class2", Type = typeof(Class2), Level = DependencyLevel.Instance },
                new Dependency { Name = "obSingTests.Classes.Class3", Type = typeof(Class3), Level = DependencyLevel.Instance },
                new Dependency { Name = "obSingTests.Classes.Class4", Type = typeof(Class4), Level = DependencyLevel.Instance }
            }
            .Select(s => new { s.Name, s.Type, s.Level });

            //Act 
            var result = myClass1Types.GetCustomDependencies();

            //Assert
            result.Where(x => x.Level == DependencyLevel.Instance).Should().HaveCount(3);
            result.Select(x => new { x.Name, x.Type , x.Level }).Should().Contain(depedencies);
        }

        [Fact]
        public void Given_Class2_When_Get_Depedencies_Then_3_Dependencies_Return()
        {
            //Arrange
            var myClass2Types = Activator.CreateInstance(typeof(Class2), true);
            var depedencies = new List<Dependency>
            {
                new Dependency { Name = "obSingTests.Classes.Class1", Type = typeof(Class1), Level = DependencyLevel.Instance },
                new Dependency { Name = "obSingTests.Classes.Class2", Type = typeof(Class2), Level = DependencyLevel.Info },
                new Dependency { Name = "obSingTests.Classes.Class3", Type = typeof(Class3), Level = DependencyLevel.Instance },
                new Dependency { Name = "obSingTests.Classes.Class4", Type = typeof(Class4), Level = DependencyLevel.Instance }
            }
            .Select(s => new { s.Name, s.Type, s.Level });

            //Act 
            var result = myClass2Types.GetCustomDependencies();

            //Assert
            result.Where(x => x.Level == DependencyLevel.Instance).Should().HaveCount(3);
            result.Select(x => new { x.Name, x.Type, x.Level }).Should().Contain(depedencies);
        }

        [Fact]
        public void Given_Class3_When_Get_Depedencies_Then_1_Dependencies_Return()
        {
            //Arrange
            var myClass3Types = Activator.CreateInstance(typeof(Class3), true);
            var depedencies = new List<Dependency>
            {
                new Dependency { Name = "obSingTests.Classes.Class3", Type = typeof(Class3), Level = DependencyLevel.Info },
                new Dependency { Name = "obSingTests.Classes.Class4", Type = typeof(Class4), Level = DependencyLevel.Instance }
            }
            .Select(s => new { s.Name, s.Type, s.Level });

            //Act 
            var result = myClass3Types.GetCustomDependencies();

            //Assert
            result.Where(x => x.Level == DependencyLevel.Instance).Should().HaveCount(1);
            result.Select(x => new { x.Name, x.Type, x.Level }).Should().Contain(depedencies);
        }

        [Fact]
        public void Given_Class4_When_Get_Depedencies_Then_No_Dependencies_Return()
        {
            //Arrange
            var myClass1Types = Activator.CreateInstance(typeof(Class4), true);
            var depedencies = new List<Dependency>
            {
                new Dependency { Name = "obSingTests.Classes.Class4", Type = typeof(Class4), Level = DependencyLevel.Info }
            }
            .Select(s => new { s.Name, s.Type, s.Level });
            
            //Act 
            var result = myClass1Types.GetCustomDependencies();

            //Assert
            result.Where(x => x.Level == DependencyLevel.Instance).Should().HaveCount(0);
            result.Select(x => new { x.Name, x.Type, x.Level }).Should().Contain(depedencies);
        }
    }
}
