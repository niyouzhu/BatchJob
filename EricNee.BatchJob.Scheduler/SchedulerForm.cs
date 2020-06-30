using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EricNee.BatchJob.Scheduler
{
    public partial class SchedulerForm : Form
    {
        public SchedulerForm()
        {
            InitializeComponent();
        }

        private App App { get; } = new App();
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            App.Run();
            LabelMsg.Text = "Started!";
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            App.Stop();
            LabelMsg.Text = "Stopped!";
        }
    }
}
