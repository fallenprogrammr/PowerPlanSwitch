using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlanSwitch
{
    public partial class SwitchService : ServiceBase
    {

        public SwitchService()
        {
            InitializeComponent();
        }
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            switch (powerStatus)
            {
                case PowerBroadcastStatus.PowerStatusChange:
                    SetPowerPlanSettingOnSystemByConnectedPowerStatus();
                    break;
                case PowerBroadcastStatus.BatteryLow:
                    SetPowerPlanSettingOnSystemTo(MaxBatterySaving);
                    break;
                default:
                    base.OnPowerEvent(powerStatus);
                    break;
            }
            return true;
        }

        private void SetPowerPlanSettingOnSystemByConnectedPowerStatus()
        {
            switch(SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Online:
                    SetPowerPlanSettingOnSystemTo(MaxPerformance);
                    break;
                case PowerLineStatus.Offline:
                    SetPowerPlanSettingOnSystemTo(Balanced);
                    break;
                default:
                    SetPowerPlanSettingOnSystemTo(Balanced);
                    break;
            }
        }

        private void SetPowerPlanSettingOnSystemTo(string powerPlanSetting)
        {
            throw new NotImplementedException();
        }
    }
}
