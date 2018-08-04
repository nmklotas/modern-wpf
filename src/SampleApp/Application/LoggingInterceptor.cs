using Castle.DynamicProxy;
using Serilog;

namespace SampleApp.Application
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Log.Information($"Entering {invocation.Method.Name}({string.Join(", ", invocation.Arguments)})");
            invocation.Proceed();
        }
    }
}