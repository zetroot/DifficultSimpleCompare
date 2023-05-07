using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DifficultSimpleCompare;

[ExcludeFromCodeCoverage]
public class TestData : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { new Transaction(42, "uid", "account"),  new Transaction(69, "uid", "account"),  false };
        
        yield return new object[] { new Transaction(42, "uid", null),       new Transaction(42, "uid", null),       true  };
        yield return new object[] { new Transaction(42, "uid", ""),         new Transaction(42, "uid", null),       true  };
        yield return new object[] { new Transaction(42, "uid", "account"),  new Transaction(42, "uid", null),       true  };
        yield return new object[] { new Transaction(42, "uid", "acc1"),     new Transaction(42, "uid", "acc2"),     true  };
        
        yield return new object[] { new Transaction(42, "uid", null),       new Transaction(null, "uid", null),     true  };
        yield return new object[] { new Transaction(42, "uid", ""),         new Transaction(null, "uid", null),     true  };
        yield return new object[] { new Transaction(42, "uid", "account"),  new Transaction(null, "uid", null),     true  };
        yield return new object[] { new Transaction(42, "uid", "acc1"),     new Transaction(null, "uid", "acc2"),   true  };
        
        yield return new object[] { new Transaction(42, "uid", null),       new Transaction(42, "diu", null),       false  };
        yield return new object[] { new Transaction(42, "uid", ""),         new Transaction(42, "diu", null),       false  };
        yield return new object[] { new Transaction(42, "uid", "account"),  new Transaction(42, "diu", null),       false  };
        yield return new object[] { new Transaction(42, "uid", "acc1"),     new Transaction(42, "diu", "acc2"),     false  };
        
        yield return new object[] { new Transaction(42, "uid", null),       new Transaction(null, "olo", null),     false  };
        yield return new object[] { new Transaction(42, "uid", ""),         new Transaction(null, "olo", null),     false  };
        yield return new object[] { new Transaction(42, "uid", "account"),  new Transaction(null, "olo", null),     false  };
        yield return new object[] { new Transaction(42, "uid", "acc1"),     new Transaction(null, "olo", "acc2"),   false  };
        
        yield return new object[] { new Transaction(42, null, "acc"),       new Transaction(null, null, "acc"),     true   };
        yield return new object[] { new Transaction(42, "", "acc"),         new Transaction(null, null, "acc"),     true   };
        yield return new object[] { new Transaction(42, "uid", "acc"),      new Transaction(null, null, "caa"),     false  };
        yield return new object[] { new Transaction(42, "uid", "acc1"),     new Transaction(null, null, "acc1"),    true   };
        
        yield return new object[] { new Transaction(42, "uid", null),       new Transaction(42, null, "acc"),       false  };
        yield return new object[] { new Transaction(42, "uid", null),       new Transaction(null, null, "acc"),     false  };
    }
}