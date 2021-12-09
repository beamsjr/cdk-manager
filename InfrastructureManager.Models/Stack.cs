namespace InfrastructureManager.Models
{
    public class Stack
    {
        public string? StackName { get; set; }
        public IList<Bucket>? Buckets { get; set; }
    }
}