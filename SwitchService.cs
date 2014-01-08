using System;
using System.ServiceProcess;
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
                    PowerPlanSwitchHelper.SetActivePowerPlan(new Guid(PowerPlans.PowerSaver));;
                    break;
                default:
                    base.OnPowerEvent(powerStatus);
                    break;
            }
            return true;
        }

        private static void SetPowerPlanSettingOnSystemByConnectedPowerStatus()
        {
            switch(SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Online:
                    PowerPlanSwitchHelper.SetActivePowerPlan(new Guid(PowerPlans.HighPerformance));
                    break;
                case PowerLineStatus.Offline:
                    PowerPlanSwitchHelper.SetActivePowerPlan(new Guid(PowerPlans.Balanced));
                    break;
                default:
                    PowerPlanSwitchHelper.SetActivePowerPlan(new Guid(PowerPlans.Balanced));
                    break;
            }
        }
    }
}
