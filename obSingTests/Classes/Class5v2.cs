using System.Collections.Generic;

namespace obSingTests.Classes
{
    public class Class5v2
    {
        private long Id { get; set; }
        private int IntProp5 { get; set; }
        private long LongProp5 { get; set; }
        private string StringProp5 { get; set; }
        private int? IntNullProp5 { get; set; }
        private long? LongNullProp5 { get; set; }
        private Class4 Class4Prop5 { get; set; }
        private IEnumerable<Class4> Class4ListProp5 { get; set; }
    }
}