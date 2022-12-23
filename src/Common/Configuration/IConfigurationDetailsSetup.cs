using Microsoft.Extensions.Configuration;

namespace Common.Configuration
{
    public interface IConfigurationDetailsSetup : ICommonProgramSetup
    {
        IConfigurationDetailsSetup WithUserSecrets<T>();
        IConfigurationDetailsSetup WithArgs(string[] args);
        IConfigurationDetailsSetup WithCustomDefaults(IConfigurationSource configurationSource);
        IConfigurationDetailsSetup WithCustomOverrides(IConfigurationSource configurationSource);
    }
}
