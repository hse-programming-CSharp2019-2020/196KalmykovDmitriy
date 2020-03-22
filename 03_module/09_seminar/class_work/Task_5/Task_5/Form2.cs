using System;
using System.Windows.Forms;

namespace Task_5
{
    public partial class ChildForm : Form
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

        public ChildForm()
        {
            InitializeComponent();
            Log($"ChildForm loaded at {DateTime.Now}");
        }

        internal ChildForm(MyLog log)
        {
            InitializeComponent();
            _log = log;
        }

        private void ChildForm_Click(object sender, EventArgs e)
        {
            Log($"Mouse clicked on the ChildForm {DateTime.Now}");
        }

        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log($"ChildForm closed at {DateTime.Now}");
        }
    }
}
