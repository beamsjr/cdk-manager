namespace cdkManager.Models
{
    public class Bucket
    {
        public string? BucketName { get; set; }
        public bool? BucketKeyEnabled { get; set; }
        public bool? EnforceSSL { get; set; }
        public bool? PublicReadAccess { get; set; }
        public string? ServerAccessLogsPrefix { get; set; }
        public bool? TransferAcceleration { get; set; }
        public bool? Versioned { get; set; }
        public string? WebsiteErrorDocument { get; set; }
        public string? WebsiteIndexDocument { get; set; }
        public int Id { get; set; }
    }
}