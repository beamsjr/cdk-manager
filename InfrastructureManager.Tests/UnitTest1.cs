using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cdkManager.Tests;

[TestFixture]
public class GeneratorServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var generator = new Services.Generator();
        var stack = new Models.Stack("TestStack")
        {
            Buckets = new List<Models.Bucket>() { new Models.Bucket("Test")}
        };

        var result = generator.BuildStack(stack);
        Assert.NotNull(result);

        result.ToString();
    }

    [Test]
    public async Task Test2()
    {
        var generator = new Services.Generator();

        var buckets = await generator.GetBuckets();

        Assert.AreEqual(2, buckets.Count);

        var b2 = buckets[1];

        var policy = await generator.GetPublicAccessBlock(b2.BucketName);

        Assert.NotNull(policy);

    }
}