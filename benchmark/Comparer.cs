using System;
using System.Collections.Generic;

namespace GetHashCodeBench;

public abstract class Comparer : IEqualityComparer<Data>
{
    public bool Equals(Data? x, Data? y)
    {
        if (x == null || y == null) return false;
        if (x.Group != y.Group)
        {
            return false;
        }

        return string.Equals(x.Key, y.Key, StringComparison.OrdinalIgnoreCase);
    }

    public abstract int GetHashCode(Data obj);
}

public class ConstHashComparer : Comparer
{
    public override int GetHashCode(Data obj) => 0;
}

public class FullKeyComparer : Comparer
{
    public override int GetHashCode(Data obj) =>
        HashCode.Combine(obj.Group.GetHashCode(), obj.Key.GetHashCode(StringComparison.OrdinalIgnoreCase));
}
