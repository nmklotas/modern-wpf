using MethodBoundaryAspect.Fody.Attributes;
using Serilog;

namespace SampleApp.Application
{
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            base.OnEntry(arg);
            Log.Information($"Entering {arg.Method.Name}({string.Join(", ", arg.Arguments)})");
        }

        public override void OnException(MethodExecutionArgs arg)
        {
            base.OnException(arg);
            Log.Error($"Exception: {arg.Exception}");
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            base.OnExit(arg);
            Log.Information($"Exiting {arg.Method.Name}. Return value: {arg.ReturnValue}");
        }
    }
}