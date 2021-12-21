using Amazon.CDK.AWS.EC2;

namespace cdkManager.Models;

public class Vpc: Entity
{
    public Vpc(string vpcName)
    {
        VpcName = vpcName;
    }

    public string VpcName { get; set; }
    public string? Cidr { get; set; }
    public bool? EnableDnsHostnames { get; set; }
    public bool? EnableDnsSupport { get; set; }

    public Amazon.CDK.AWS.EC2.Vpc Build(Amazon.CDK.Stack stack)
    {
        return new Amazon.CDK.AWS.EC2.Vpc(stack, VpcName, new VpcProps()
        {
            Cidr = Cidr,
            //DefaultInstanceTenancy = DefaultInstanceTenancy,
            EnableDnsHostnames = EnableDnsHostnames,
            EnableDnsSupport = EnableDnsSupport
        });
    }

}