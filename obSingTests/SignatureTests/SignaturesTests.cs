using FluentAssertions;
using obSing;
using obSingTests.Classes;
using Xunit;

namespace obSingTests.DependenciesTests
{
    public class SignaturesTests
    {
        [Fact]
        public void Given_Class1_And_Class1v1_When_Get_Signature_Then_Different_Hash_Returns()
        {
            //Arrange
            var typeClass1 = typeof(Class1);
            var typeClass1v2 = typeof(Class1v2);

            //Act 
            var class1Hash = typeClass1.GetSignature();
            var class1v2Hash = typeClass1v2.GetSignature();

            //Assert
            class1Hash.Should().NotBe(class1v2Hash);
            class1Hash.Should().Be(-272630006);
            class1v2Hash.Should().Be(-116230690);
        }

        [Fact]
        public void Given_Class1_And_Class1_When_Get_Signature_Then_Same_Hash_Returns()
        {
            //Arrange
            var typeClass1 = typeof(Class1);

            //Act 
            var class1Hash_1 = typeClass1.GetSignature();
            var class1Hash_2 = typeClass1.GetSignature();

            //Assert
            class1Hash_1.Should().Be(class1Hash_2);
            class1Hash_1.Should().Be(-272630006);
        }

        [Fact]
        public void Given_Class2_And_Class2v1_When_Get_Signature_Then_Different_Hash_Returns()
        {
            //Arrange
            var typeClass2 = typeof(Class2);
            var typeClass2v2 = typeof(Class2v2);

            //Act 
            var class2Hash = typeClass2.GetSignature();
            var class2v2Hash = typeClass2v2.GetSignature();

            //Assert
            class2Hash.Should().NotBe(class2v2Hash);
        }

        [Fact]
        public void Given_Class3_And_Class3v1_When_Get_Signature_Then_Different_Hash_Returns()
        {
            //Arrange
            var typeClass3 = typeof(Class3);
            var typeClass3v2 = typeof(Class3v2);

            //Act 
            var class3Hash = typeClass3.GetSignature();
            var class3v2Hash = typeClass3v2.GetSignature();

            //Assert
            class3Hash.Should().NotBe(class3v2Hash);
        }

        [Fact]
        public void Given_Class4_And_Class4v1_When_Get_Signature_Then_Different_Hash_Returns()
        {
            //Arrange
            var typeClass4 = typeof(Class4);
            var typeClass4v2 = typeof(Class4v2);

            //Act 
            var class4Hash = typeClass4.GetSignature();
            var class4v2Hash = typeClass4v2.GetSignature();

            //Assert
            class4Hash.Should().NotBe(class4v2Hash);
        }

        [Fact]
        public void Given_Class5_And_Class5v1_When_Get_Signature_Then_Different_Hash_Returns()
        {
            //Arrange
            var typeClass5 = typeof(Class5);
            var typeClass5v2 = typeof(Class5v2);

            //Act 
            var class5Hash = typeClass5.GetSignature();
            var class5v2Hash = typeClass5v2.GetSignature();

            //Assert
            class5Hash.Should().NotBe(class5v2Hash);
        }
    }
}
