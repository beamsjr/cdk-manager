using InfrastructureManager.Models;

namespace InfrastructureManager.Services
{
    public class Generator
    {
        public Amazon.CDK.CXAPI.CloudAssembly BuildStack(Stack model) 
        {
            var app = new Amazon.CDK.App();
            var stack = new Amazon.CDK.Stack(app, model.StackName);

            model.Buckets?.BuildBuckets(stack);

            return app.Synth();

        }
    }

}