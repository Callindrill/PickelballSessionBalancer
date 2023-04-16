using PickleballBracket.Domain;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;

namespace PickleballBracket.Tests.Domain;

public class BaseEntityTests
{

    [Fact]
    internal void GetHashCode_DifferentGenericTypeSameId_ReturnsDifferentResult()
    {
        var a = new TestEntityA();
        var b = new TestEntityB();
        a.Id.Should().Be(b.Id);
        a.GetHashCode().Should().NotBe(b.GetHashCode());
    }

    [Fact]
    internal void GetHashCode_SameGenericType_ReturnsDifferentResult()
    {
        var a1 = new TestEntityIncremented();
        var a2 = new TestEntityIncremented();

        a2.Id.Should().BeGreaterThan(a1.Id);
        a1.GetHashCode().Should().NotBe(a2.GetHashCode());
    }

    [Fact]
    internal void Constructor_IdGeneration_IsThreadsafeAndNonColliding()
    {
        var concurrentBag = new ConcurrentBag<TestEntityIncremented>();
        var itemsToCreate = 1_000_000; //this takes about a second on my machine. Plenty of time for a threading collision to occur. 
        var result = Parallel.For(0, itemsToCreate, i =>
        {
            concurrentBag.Add(new TestEntityIncremented());
        });
        
        result.IsCompleted.Should().BeTrue();
        var list = concurrentBag.ToList();

        list.Select(v => v.Id).ToList().Should().OnlyHaveUniqueItems();
        list.Select(i => i.GetHashCode()).Should().OnlyHaveUniqueItems();
        list.Should().HaveCount(itemsToCreate);
    }

    private class TestEntityIncremented : BaseEntity<TestEntityIncremented>
    {
        public TestEntityIncremented() : base() { }
    }

    private class TestEntityA : BaseEntity<TestEntityA>
    {
        // not calling the base as we want direct control over the Id here.
        public TestEntityA() 
        {
            Id = 1;
        }
    }

    private class TestEntityB : BaseEntity<TestEntityB>
    {
        // not calling the base as we want direct control over the Id here.
        public TestEntityB() 
        {
            Id = 1;
        }
    }
}
