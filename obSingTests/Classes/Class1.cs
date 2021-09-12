using System;
using System.Collections.Generic;

namespace obSingTests.Classes
{
    public class Class1
    {
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

        private Class1()
        {
        }
    }
}