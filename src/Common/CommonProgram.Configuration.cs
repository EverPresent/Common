using Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace Common
{
    public partial class CommonProgram : IConfigurationDetailsSetup
    {
        private IConfigurationRoot _configurationRoot;
        private readonly List<Type> _userSecretsTypes = new();
        private readonly List<string[]> _args = new();
        private readonly List<IConfigurationSource> _customDefaults = new();
        private readonly List<IConfigurationSource> _customOverrides = new();

        public IConfigurationDetailsSetup WithConfiguration()
        {
            return this;
        }

        public IConfigurationDetailsSetup WithUserSecrets<T>()
        {
            _userSecretsTypes.Add(typeof(T));
            return this;
        }

        public IConfigurationDetailsSetup WithArgs(string[] args)
        {
            _args.Add(args);
            return this;
        }

        public IConfigurationDetailsSetup WithCustomDefaults(IConfigurationSource configurationProvider)
        {
            _customDefaults.Add(configurationProvider);
            return this;
        }

        public IConfigurationDetailsSetup WithCustomOverrides(IConfigurationSource configurationProvider)
        {
            _customOverrides.Add(configurationProvider);
            return this;
        }

        private void SetupConfiguration()
        {
            var builder = new ConfigurationBuilder();
            
            foreach (var customDefault in _customDefaults)
                builder.Add(customDefault);
            
            builder.AddJsonFile("appsettings.json");

            foreach (var userSecret in _userSecretsTypes)
                builder.AddUserSecrets(userSecret.Assembly);

            builder.AddEnvironmentVariables();

            foreach (var args in _args)
                builder.AddCommandLine(args);

            foreach (var customOverride in _customOverrides)
                builder.Add(customOverride);

            _configurationRoot = builder.Build();
        }
    }
}
