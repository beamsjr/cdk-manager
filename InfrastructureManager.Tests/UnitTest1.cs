using NUnit.Framework;
using System.Collections.Generic;

namespace InfrastructureManager.Tests
{
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
            var stack = new Models.Stack
            {
                Buckets = new List<Models.Bucket>() { new Models.Bucket() { BucketName = "Test" } }
            };

            var result = generator.BuildStack(stack);
            Assert.NotNull(result);
        }
    }
}