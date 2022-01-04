namespace cdkManager.Models
{
    public class Stack : Entity
    {
        public Stack()
        {
            Buckets = new List<Bucket>();
            Vpcs = new List<Vpc>();
            Created = DateTime.Now;
        }
        public Stack(string name)
        {
            StackName = name;
            Buckets = new List<Bucket>();
            Vpcs = new List<Vpc>();
            Created = DateTime.Now;
        }

        public string? StackName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Deployed { get; set; }

        public IList<Bucket>? Buckets { get; set; }
        public IList<Vpc>? Vpcs { get; set; }

    }
}