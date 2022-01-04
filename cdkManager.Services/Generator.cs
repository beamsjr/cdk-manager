using Amazon;
using Amazon.S3.Model;
using cdkManager.Models;

namespace cdkManager.Services
{
    public interface IGenerator
    {
        Amazon.CDK.CXAPI.CloudAssembly BuildStack(Models.Stack model);
    }
    public class Generator : IGenerator
    {
        public Amazon.CDK.CXAPI.CloudAssembly BuildStack(Models.Stack model)
        {
            var app = new Amazon.CDK.App();

            var stack = new Amazon.CDK.Stack(app, model.StackName.Replace("_",""));

            if (model.Buckets != null)
            {
                foreach (var bucket in model.Buckets)
                {
                    if (bucket?.BucketName != null)
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

            return app.Synth();
        }


        public async Task<List<S3Bucket>> GetBuckets()
        {
            var client = new Amazon.S3.AmazonS3Client();

            var request = await client.ListBucketsAsync();

            return request.Buckets;
        }

        public async Task<S3AccessControlList> GetACL(string bucketName)
        {
            var client = new Amazon.S3.AmazonS3Client();

            var request = await client.GetACLAsync(
                new GetACLRequest()
                {
                    BucketName = bucketName
                });

            return request.AccessControlList;
        }

        public async Task<PublicAccessBlockConfiguration> GetPublicAccessBlock(string bucketName)
        {
            var client = new Amazon.S3.AmazonS3Client();

            var request = await client.GetPublicAccessBlockAsync(new GetPublicAccessBlockRequest()
            { BucketName = bucketName });

            return request.PublicAccessBlockConfiguration;
        }

        public async Task<Bucket> ImportBucket(string bucketName)
        {
            var acl = await GetACL(bucketName);
            var publicAccessBlock = await GetPublicAccessBlock(bucketName);

            return new Bucket(bucketName)
            {
                PublicReadAccess = !publicAccessBlock.IgnorePublicAcls
            };

        }
    }

}