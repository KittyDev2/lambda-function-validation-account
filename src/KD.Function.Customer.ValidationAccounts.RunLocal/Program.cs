using Amazon.Lambda.Core;
using KD.Function.Customer.ValidationAccounts;

public class Program
{
    public static async Task Main(string[] args)
    {       
        var function = new Function();
        var context = new TestLambdaContext();
            
        await function.FunctionHandler(new { }, context);
            
        Console.WriteLine("Function executed successfully!");
    }
}
    
public class TestLambdaContext : ILambdaContext
{
    private IClientContext _clientContext = null!;
    private TimeSpan _remainingTime = TimeSpan.FromSeconds(2);
    public string RequestId => Guid.NewGuid().ToString();
    IClientContext ILambdaContext.ClientContext => _clientContext;
    public string FunctionName => "TestFunction";
    public string FunctionVersion => "1.0";
    public ICognitoIdentity Identity { get; } = null!;
    public string InvokedFunctionArn => "test-arn";
    public ILambdaLogger Logger => new TestLambdaLogger();
    public string LogGroupName { get; } = "LogGroupName";
    public string LogStreamName { get; } = "LogStreamName";
    public int MemoryLimitInMB => 512;
    TimeSpan ILambdaContext.RemainingTime => _remainingTime;
    public string AwsRequestId { get; } = Guid.NewGuid().ToString();
}
    
public class TestLambdaLogger : ILambdaLogger
{
    public void Log(string message) => Console.WriteLine(message);
    public void LogLine(string message) => Console.WriteLine(message);
}