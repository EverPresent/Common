using Common.Configuration;
using Common.Logging;
using Common.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public interface ICommonProgramSetup : IConfigurationSetup, ILoggingSetup, IMessagingSetup
    {
        ICommonProgramSetup WithAdditionalServices(Action<IServiceCollection, IConfigurationSetup> configureAdditionalServices);

        ICommonProgramSetup WithPostConfigurationStep(Action<IServiceProvider> postConfigurationStep);

        ICommonProgramSetup WithPostConfigurationStep(Func<IServiceProvider, CancellationToken, Task> postConfigurationStep);

        Task Run();
    }








}
