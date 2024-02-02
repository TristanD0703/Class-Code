namespace Set;
using Node;

public class Tests<T>
{



    [Test]
    [TestCase(12, 3, ExpectedResult = 4)] // string
    [TestCase(12, 2, ExpectedResult = 6)] // int
    [TestCase(12, 4, ExpectedResult = 3)] // double
    [TestCase(12, 4, ExpectedResult = 3)] // Node
    public Set<T> TestSetIndex(Set<T> set, int i)
    {
        return set[i];
    }
    [Test]
    public Set<T> TestSetAdd(Set<T> set, T elem)
    {
        return set + elem;
    }

    [Test]
    public Set<T> TestSetSubtract(Set<T> set1, Set<T> set2)
    {
        return set1 - set2;
    }

    [Test]
    public Set<T> TestSetUnion(Set<T> set1, Set<T> set2)
    {
        return set1;
    }

    [Test]
    public Set<T> TestSetIntersect(Set<T> set1, Set<T> set2)
    {
        return set1;
    }

    [Test]
    public void TestSetComparison(Set<T> set1, Set<T> set2)
    {
        Assert.True(set1 > set2);
        Assert.True(set2 < set1);
    }

    [Test]
    public void TestSetEquality(Set<T> set1, Set<T> set2)
    {
        Assert.True(set1 == set2);
    }

    [Test]
    public void TestSetInequality(Set<T> set1, Set<T> set2)
    {
        Assert.True(set1 != set2);
    }

    [Test]
    public void TestSetEmptiness(Set<T> set)
    {
        Assert.NotNull(set);
        Assert.False(set);
    }

    [Test]
    public void TestSetHasSomething(Set<T> set)
    {
        Assert.NotNull(set);
        Assert.True(set);
    }
}