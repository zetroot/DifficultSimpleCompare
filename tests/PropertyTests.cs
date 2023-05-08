using FluentAssertions;
using FsCheck;

namespace DifficultSimpleCompare;

public class PropertyTests
{
    [FsCheck.NUnit.Property]
    public void Except_Consistent_WithEquals()
    {
        var sut = new PatchedTransactionComparer();
        Prop.ForAll<Transaction, Transaction>((l, r) =>
        {
            var equals = sut.Equals(l, r);
            var diff = new[] { l }.Except(new[] { r }, sut).ToList();
            diff.Any().Should().Be(!equals);
        }).QuickCheckThrowOnFailure();
    }
}
