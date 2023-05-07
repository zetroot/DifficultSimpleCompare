using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;

namespace DifficultSimpleCompare;

[TestFixture, ExcludeFromCodeCoverage]
public class PatchedComparerTests
{
    [Test, TestCaseSource(typeof(TestData))]
    public void Equals_WhenCalled_ReturnsExpectedValue(Transaction x, Transaction y, bool expected)
    {
        //arrange
        var sut = new PatchedTransactionComparer();
        
        //act & assert
        sut.Equals(x, y).Should().Be(expected);
        sut.Equals(y, x).Should().Be(expected);
    }


    [Test, TestCaseSource(typeof(TestData))]
    public void Except_WhenCalled_ReturnsEmptyCollection(Transaction x, Transaction y, bool isDiffEmpty)
    {
        //arrange
        var sut = new PatchedTransactionComparer();
        var currentCollection = new[]{x};
        var previousCollection = new []{y};
        
        //act
        var diff = currentCollection.Except(previousCollection, sut).ToList();
        
        //assert
        if (isDiffEmpty)
            diff.Should().BeEmpty();
        else
            diff.Should().NotBeEmpty();
    }
}