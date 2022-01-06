// See https://aka.ms/new-console-template for more information
// Event Driven

using SimpleHeartbeat_Service;
using Topshelf;

Console.WriteLine("Hello, World!");


// Service Code
var exitCode = HostFactory.Run(x =>
    {
        // Setup the Service
        x.Service<Heartbeat>(s =>
        {
            s.ConstructUsing(heartbeat => new Heartbeat());
            s.WhenStarted(Heartbeat => Heartbeat.Start());
            s.WhenStopped(Heartbeat => Heartbeat.Stop());
        });

        // How it should Run, using a simple way to run this service as local system
        // Privelage levels
        x.RunAsLocalService();

        // no spaces
        x.SetServiceName("_HeartbeatService");
        x.SetDisplayName("_Heartbeat Service");
        x.SetDescription("Sample heartbeat service that writes into a file every second.");
    });

// convert the enum to an int and passing it out
int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
Environment.ExitCode = exitCodeValue;
