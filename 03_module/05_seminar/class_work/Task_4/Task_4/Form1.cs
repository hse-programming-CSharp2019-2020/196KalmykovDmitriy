using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4
{
    public partial class Form1 : Form
    {
        private readonly Estimates _estimates = new Estimates();

        private static readonly Random Rnd = new Random();

        private readonly Form2 _form2 = new Form2();
        public Form1()=>
            InitializeComponent();

        // ALTERNATIVE: could use timer and every tick change value and text.

        /// <summary>
        /// Change value and print info.
        /// </summary>
        private async void ChangeValues()
        {
            var i = 0;
            while (i < 1000)
            {
                _estimates.Add(Rnd.NextDouble());
                _form2.xMin.Text = $"xMin: {_estimates.Xmin:f5}";
                _form2.xMax.Text = $"xMax: {_estimates.Xmax:f5}";
                _form2.Average.Text = $"Average: {_estimates.Average:f5}";
                _form2.SampleSize.Text = $"Sample size: {_estimates.Numb} from 1000";
                _form2.ASD.Text = $"A.S.D.: {_estimates.Deviation:f5}";

                // Pause 20 millisecond.
                await Task.Delay(20);

                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check button text.
            if (button1.Text == "Exit")
                Close();

            // Start async method.
            ChangeValues();

            _form2.Show();

            button1.Text = "Exit";
        }
    }
}
