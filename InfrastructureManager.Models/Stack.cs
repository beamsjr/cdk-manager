namespace cdkManager.Models
{
    public class Stack
    {
        public Stack(string name)
        {
            StackName = name;
            Buckets = new List<Bucket>();
        }
        public int Id { get; set; }
        public string StackName { get; set; }
        public IList<Bucket> Buckets { get; set; }
    }
}