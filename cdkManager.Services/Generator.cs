using Amazon;
using Amazon.S3.Model;
using cdkManager.Models;

namespace cdkManager.Services
{
    public class Generator
    {
        public Amazon.CDK.CXAPI.CloudAssembly BuildStack(Stack model)
        {
            var app = new Amazon.CDK.App();
            
            var stack = new Amazon.CDK.Stack(app, model.StackName);

            foreach (var bucket in model.Buckets)
            {
                bucket.Build(stack);
            }

            return app.Synth();
        }


        public async Task<List<S3Bucket>> GetBuckets()
        {
            var  client = new Amazon.S3.AmazonS3Client();

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
                {BucketName = bucketName});

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