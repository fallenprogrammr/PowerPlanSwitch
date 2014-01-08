using System.ServiceProcess;

namespace PowerPlanSwitch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[] 
            { 
                new SwitchService() 
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
