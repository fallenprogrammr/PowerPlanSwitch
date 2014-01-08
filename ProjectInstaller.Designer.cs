namespace PowerPlanSwitch
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.switchServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.switchServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // switchServiceProcessInstaller
            // 
            this.switchServiceProcessInstaller.Password = null;
            this.switchServiceProcessInstaller.Username = null;
            // 
            // switchServiceInstaller
            // 
            this.switchServiceInstaller.DisplayName = "Power plan switch service";
            this.switchServiceInstaller.ServiceName = "PowerPlanSwitchService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.switchServiceProcessInstaller,
            this.switchServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller switchServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller switchServiceInstaller;
    }
}