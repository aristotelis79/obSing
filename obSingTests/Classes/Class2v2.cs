using System.Collections.Generic;

namespace obSingTests.Classes
{
    public class Class2v2
    {
        private long Id { get; set; }
        private int IntProp2 { get; set; }
        private long LongProp2 { get; set; }
        private string StringProp2 { get; set; }
        private int IntNullProp2 { get; set; }
        private long LongNullProp2 { get; set; }
        private Class1 Class1Prop2 { get; set; }
        private List<Class1> Class1ListProp2 { get; set; }
        private Class2 Class2Prop2 { get; set; }
        private List<Class2> Class2ListProp2 { get; set; }
        private Class3 Class3Prop2 { get; set; }
        private List<Class3> Class3ListProp2 { get; set; }
        private Dictionary<Class1, Class3> DictionaryProp2 { get; set; }
    }
}