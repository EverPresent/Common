using Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Common
{
    public partial class CommonProgram : ICommonProgramSetup
    {
        private CommonProgram() { }

        public static ICommonProgramSetup Setup => new CommonProgram();

        public ICommonProgramSetup WithAdditionalServices(Action<IServiceCollection, IConfigurationSetup> configureAdditionalServices)
        {
            throw new NotImplementedException();
        }

        public ICommonProgramSetup WithPostConfigurationStep(Action<IServiceProvider> postConfigurationStep)
        {
            throw new NotImplementedException();
        }

        public ICommonProgramSetup WithPostConfigurationStep(Func<IServiceProvider, CancellationToken, Task> postConfigurationStep)
        {
            throw new NotImplementedException();
        }

        public Task Run()
        {
            SetupEverything();
            DebugStuff();
            return Task.CompletedTask;
        }

        private void SetupEverything()
        {
            SetupConfiguration();
            SetupLogging();
        }

        private void DebugStuff()
        {
            foreach (var configVars in _configurationRoot.AsEnumerable())
            {
                Log.Debug("VAR: {key}: {value}", configVars.Key, configVars.Value);
            }
        }
    }
}