obSing - Create Singature for C# Classes 
===

Generate a unique hash integer for a class base on his properties.

Install and QuickStart
---

```
Install-Package obSing
```

NuGet page links - [obSing](https://www.nuget.org/packages/obSing/)

QuickStart, you can call `SignatureObject.GetSignature`.

```csharp
public class Class1
{
    /// Important Properties must have getter even private available
    private int Id { get; set; }
    private int IntProp1 { get; set; }
    private long LongProp1 { get; set; }
    private string StringProp1 { get; set; }
    private int? IntNullProp1 { get; set; }
    private long? LongNullProp1 { get; set; }
    private Class1 Class1Prop1 { get; set; }
    private IEnumerable<Class1> Class1IEnumerableProp1 { get; set; }
    private Class2 Class2Prop1 { get; set; }
    private List<Class2> Class2ListProp1 { get; set; }
    private Class4 Class4Prop1 { get; set; }
    private Dictionary<string,Class4> Class4Dictionary { get; set; }

    private Dictionary<Class2, Dictionary<Class2, Class3>> DictionaryProp1 { get; set; }

    /// Important must have parameterless ctor available even private
    private Class1() 
    {
    }
}

var class1Hash = typeof(Class1).GetSignature();

//  or
var c1 = new Class1();
var class1Hash = c1.GetSignature();

//  or
var class1Hash = SignatureObject.GetSignature<Class1>();
```

License
---
This library is under the MIT License.
