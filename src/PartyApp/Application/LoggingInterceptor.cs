using Castle.DynamicProxy;
using NLog;

namespace PartyApp.Application
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var logger = LogManager.GetCurrentClassLogger(invocation.TargetType);
            logger.Info($"Entering {invocation.Method.Name}({string.Join(", ", invocation.Arguments)})");
            invocation.Proceed();
        }
    }
}