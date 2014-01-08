using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PowerPlanSwitch
{
    public static class PowerPlanSwitchHelper
    {
        [DllImportAttribute("powrprof.dll", EntryPoint = "PowerSetActiveScheme")]
        static extern uint PowerSetActiveScheme(IntPtr userPowerKey, ref Guid activePolicyGuid);

        [DllImportAttribute("powrprof.dll", EntryPoint = "PowerGetActiveScheme")]
        static extern uint PowerGetActiveScheme(IntPtr userPowerKey, out IntPtr activePolicyGuid);

        [DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
        static extern uint PowerReadFriendlyName(IntPtr rootPowerKey,ref Guid schemeGuid,IntPtr subGroupOfPowerSettingGuid,IntPtr powerSettingGuid,StringBuilder buffer,ref uint bufferSize);

        private static string GetPowerPlanName(Guid guid)
        {
            var buffer = new StringBuilder();
            uint bufferSize = 0;
            const uint bufferSizeTooSmall = 234;
            var response = PowerReadFriendlyName(IntPtr.Zero, ref guid, IntPtr.Zero, IntPtr.Zero, buffer, ref bufferSize);
            if (response == bufferSizeTooSmall)
            {
                buffer.Capacity = (int)bufferSize;
                response = PowerReadFriendlyName(IntPtr.Zero, ref guid,IntPtr.Zero, IntPtr.Zero, buffer, ref bufferSize);
            }
            if (response != 0) //the api call returns 0 on success.
            {
                throw new Exception("Could not get the name of the power plan: " + guid + " , the win32 api call failed.");
            }
            return buffer.ToString();
        }

        private static string GetActivePowerPlan()
        {
            Guid activeScheme;
            IntPtr ptr;
            if (PowerGetActiveScheme((IntPtr)null, out ptr) == 0)
            {
                activeScheme = (Guid)Marshal.PtrToStructure(ptr, typeof(Guid));
                Marshal.FreeHGlobal(ptr);
            }
            else
            {
                throw new Exception("Could not retrieve the active power plan, the win32 api call failed.");
            }
            return GetPowerPlanName(activeScheme);
        }

        public static void SetActivePowerPlan(Guid planId)
        {
            PowerSetActiveScheme(IntPtr.Zero, ref planId);
        }
    }
}
