namespace cdkManager.Models
{
    public class Stack
    {
        public Stack()
        {
            Buckets = new List<Bucket>();
            Created = DateTime.Now;
        }
        public Stack(string name)
        {
            StackName = name;
            Buckets = new List<Bucket>();
            Created = DateTime.Now;
        }

        public int Id { get; set; }
        public string? StackName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Deployed { get; set; }

        public IList<Bucket>? Buckets { get; set; }
    }
}