namespace cdkManager.Models
{
    public class Bucket : Entity
    {
        public Bucket()
        {

        }

        public Bucket(string bucketName)
        {
            BucketName = bucketName;
        }

        public string? BucketName { get; set; }
        public bool? BucketKeyEnabled { get; set; }
        public bool? EnforceSSL { get; set; }
        public bool? PublicReadAccess { get; set; }
        public string? ServerAccessLogsPrefix { get; set; }
        public bool? TransferAcceleration { get; set; }
        public bool? Versioned { get; set; }
        public string? WebsiteErrorDocument { get; set; }
        public string? WebsiteIndexDocument { get; set; }



    }
}