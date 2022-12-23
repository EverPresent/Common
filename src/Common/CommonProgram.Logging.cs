using Serilog;

namespace Common
{
    public partial class CommonProgram
    {
        private bool _withLogging;

        public ICommonProgramSetup WithLogging()
        {
            _withLogging = true;
            return this;
        }

        private void SetupLogging()
        {
            if (_withLogging)
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .CreateLogger();

                Log.Information("Starting Application...");
            }
        }
    }
}
