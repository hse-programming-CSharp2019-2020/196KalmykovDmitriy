using System;
using System.Windows.Forms;

namespace Task_5
{
    public partial class ParentForm : Form
    {
        // Logger.
        private readonly MyLog _log;

        /// <summary>
        /// Log.
        /// </summary>
        /// <param name="message"> Message for logging </param>
        private void Log(string message)
        {
            MessageBox.Show(message);
            _log.WriteToLog(message);
        }

        public ParentForm()
        {
            InitializeComponent();
            _log = new MyLog();

            Log($"ParentForm and ChildForm loaded at {DateTime.Now}");

            var form2 = new ChildForm(_log);
            form2.Show();
        }

        private void ParentForm_Click(object sender, EventArgs e)
        {
            Log($"Mouse clicked on the ParentForm at {DateTime.Now}");
        }

        private void ParentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log("ParentForm closed at " + DateTime.Now);
            _log.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Log($"Button 1 was pressed at {DateTime.Now}");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Log($"Button 2 was pressed at {DateTime.Now}");
        }
    }
}
