namespace cdkManager.Models
{
    public class Bucket : Entity
    {
        public Bucket(string bucketName)
        {
            BucketName = bucketName;
        }

        public string BucketName { get; set; }
        public bool? BucketKeyEnabled { get; set; }
        public bool? EnforceSSL { get; set; }
        public bool? PublicReadAccess { get; set; }
        public string? ServerAccessLogsPrefix { get; set; }
        public bool? TransferAcceleration { get; set; }
        public bool? Versioned { get; set; }
        public string? WebsiteErrorDocument { get; set; }
        public string? WebsiteIndexDocument { get; set; }

        public Amazon.CDK.AWS.S3.Bucket Build(Amazon.CDK.Stack stack)
        {
            return new Amazon.CDK.AWS.S3.Bucket(stack, BucketName, new Amazon.CDK.AWS.S3.BucketProps
            {
                Versioned = Versioned,
                BucketKeyEnabled = BucketKeyEnabled,
                EnforceSSL = EnforceSSL,
                PublicReadAccess = PublicReadAccess,
                ServerAccessLogsPrefix = ServerAccessLogsPrefix,
                TransferAcceleration = TransferAcceleration,
                WebsiteErrorDocument = WebsiteErrorDocument,
                WebsiteIndexDocument = WebsiteIndexDocument
            });
        }

    }
}