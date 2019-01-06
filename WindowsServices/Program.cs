using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WindowsServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start serwisu
            var exitCode = HostFactory.Run(x =>
            {
                // s jak serwis
                x.Service<Pulsator>(s =>
                {
                    s.ConstructUsing(pulsator => new Pulsator());
                    s.WhenStarted(pulsator => pulsator.Start());  
                    s.WhenStopped(pulsator => pulsator.Stop());
                });

                // jak chcesz aby serwis został uruchomiony i jako kto zaloguj
                x.RunAsLocalSystem();

                // Nazwa serwisu bez spacji
                x.SetServiceName("PulsatorService");
                x.SetDisplayName("Pulsator Service");

                //opis
                x.SetDescription("To jest testowy serwis do nauki ");
            });


            // 
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetType());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
