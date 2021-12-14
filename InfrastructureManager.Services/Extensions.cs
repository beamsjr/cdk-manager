using cdkManager.Models;

namespace cdkManager.Services
{
    public static class Extensions
    {

        public static void BuildBuckets(this IList<Bucket> buckets, Amazon.CDK.Stack stack)
        {

            foreach (var bucket in buckets)
            {
                new Amazon.CDK.AWS.S3.Bucket(stack, bucket.BucketName, new Amazon.CDK.AWS.S3.BucketProps
                {
                    Versioned = bucket.Versioned,
                    BucketKeyEnabled = bucket.BucketKeyEnabled,
                    EnforceSSL = bucket.EnforceSSL,
                    PublicReadAccess = bucket.PublicReadAccess,
                    ServerAccessLogsPrefix = bucket.ServerAccessLogsPrefix,
                    TransferAcceleration = bucket.TransferAcceleration,
                    WebsiteErrorDocument = bucket.WebsiteErrorDocument,
                    WebsiteIndexDocument = bucket.WebsiteIndexDocument
                });
            }
        }

    }

}