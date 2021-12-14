using cdkManager.Models;
using Microsoft.AspNetCore.Components;

namespace cdkManager.web.Shared
{

    public partial class StackListComponent : ComponentBase
    {
        public IList<Models.Stack>? Stacks { get; set; } = new List<Models.Stack>()
        {
            new("Test Stack")
            {
                Buckets = new List<Bucket>()
                {
                    new() {BucketName = "Test Bucket"}
                }
            },
            new("Test Stack2")
            {
                Buckets = new List<Bucket>()
                {
                    new() {BucketName = "Test Bucket2"}
                }
            }
        };


        public class Item
        {
            public Item(string text, int id, string type)
            {
                Text = text;
                Id = id;
                Type = type;
            }

            public string Text { get; set; }
            public int Id { get; set; }
            public IEnumerable<Item> Children { get; set; }
            public string Type { get; set; }
        }

        private IEnumerable<Item> Items => BuildMenu();
        IList<Item> _expandedNodes = new List<Item>();
        private Item? _selectedNode { get; set; }

        private IEnumerable<Item> BuildMenu()
        {
            var result = new List<Item>();

            if (Stacks == null) return result;

            result.AddRange(
                Stacks.Select(
                    stack =>
                        new Item(stack.StackName, stack.Id, "Stack")
                        {
                            Children = new List<Item>() { BuildBuckets(stack) }.ToArray()
                        }));

            return result;
        }

        private Item BuildBuckets(Models.Stack stack)
        {
            var s3Buckets = new List<Item>();
            foreach (var stackBucket in stack.Buckets)
            {

                s3Buckets.Add(new Item(stackBucket.BucketName, stackBucket.Id, "Bucket"));
            }

            return new Item("S3 Buckets", 0, "Menu") { Children = s3Buckets.ToArray() };
        }

    }
}
