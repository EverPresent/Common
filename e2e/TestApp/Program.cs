using Common;
using Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace TestApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await CommonProgram.Setup
                .WithLogging()
                .WithConfiguration()
                    .WithUserSecrets<Program>()
                    .WithArgs(args)
                    .WithCustomOverrides(MostImportantSettings)
                //.WithMessaging()
                //    .BindCommand<SendEmailConsumer>("TestApp.TestClasses:SendEmail", "test-app-send-email")
                //    .BindCommand<ProcessBatchConsumer>("TestApp.TestClasses:ProcessBatch", "test-app-process-batch")
                //    .BindEvent<FileChangedConsumer>("TestApp.TestClasses:FileChanged", "test-app-file-changed")
                //    .BindEvent<EmailReceivedConsumer>("TestApp.TestClasses:EmailReceived", "test-app-email-received")
                //    .AlsoPublishes<EmailSent>()
                //.WithAdditionalServices(ConfigureServices)
                //.WithPostConfigurationStep(ApplyDatabaseMigrationsAsync)
                //.WithPostConfigurationStep(CreateGcpPubSubSubscriptions)
                .Run();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection services, IConfigurationSetup configurationSetup)
        {

        }

        private static Task ApplyDatabaseMigrationsAsync(IServiceProvider services, CancellationToken token)
        {
            return Task.CompletedTask;
        }

        private static Task CreateGcpPubSubSubscriptions(IServiceProvider services, CancellationToken token)
        {
            return Task.CompletedTask;
        }

        private static IConfigurationSource MostImportantSettings =>
            new MemoryConfigurationSource();
    }
}