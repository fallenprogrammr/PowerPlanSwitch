using System.ComponentModel;
using System.Configuration.Install;

namespace PowerPlanSwitch
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
