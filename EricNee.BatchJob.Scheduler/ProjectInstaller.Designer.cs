namespace EricNee.BatchJob.Scheduler
{
    partial class SchedulerProjectInstaller
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
            this.SchedulerServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SchedulerServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // SchedulerServiceProcessInstaller
            // 
            this.SchedulerServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.SchedulerServiceProcessInstaller.Password = null;
            this.SchedulerServiceProcessInstaller.Username = null;
            // 
            // SchedulerServiceInstaller
            // 
            this.SchedulerServiceInstaller.Description = "BatchJob.Scheduler";
            this.SchedulerServiceInstaller.DisplayName = "BatchJob.Scheduler";
            this.SchedulerServiceInstaller.ServiceName = "BatchJob.Scheduler";
            this.SchedulerServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // SchedulerProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SchedulerServiceProcessInstaller,
            this.SchedulerServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SchedulerServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller SchedulerServiceInstaller;
    }
}