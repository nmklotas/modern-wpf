using MethodBoundaryAspect.Fody.Attributes;
using NLog;

namespace PartyApp.Application
{
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            base.OnEntry(arg);
            GetLogger(arg).Info($"Entering {arg.Method.Name}({string.Join(", ", arg.Arguments)})");
        }

        public override void OnException(MethodExecutionArgs arg)
        {
            base.OnException(arg);
            GetLogger(arg).Error($"Exception: {arg.Exception}");
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            base.OnExit(arg);
            GetLogger(arg).Info($"Exiting {arg.Method.Name}. Return value: {arg.ReturnValue}");
        }

        private static Logger GetLogger(MethodExecutionArgs arg)
        {
            return LogManager.GetCurrentClassLogger(arg.Method.DeclaringType);
        }
    }
}