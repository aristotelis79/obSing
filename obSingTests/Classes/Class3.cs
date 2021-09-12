using System;
using System.Collections.Generic;

namespace obSingTests.Classes
{
    public class Class3
    {
        private Guid Id { get; set; }
        private int IntProp3 { get; set; }
        private long LongProp3 { get; set; }
        private string StringProp3 { get; set; }
        private int? IntNullProp3 { get; set; }
        private long? LongNullProp3 { get; set; }
        private Class4 Class4Prop3 { get; set; }
        private List<Class4> Class4ListProp3 { get; set; }
        private Dictionary<Class3, Dictionary<Class3,List<Class4>>> DictionaryProp3 { get; set; }

        internal Class3()
        {

        }
    }
}