using System.Drawing;
using System.Windows.Forms;

namespace Task_5
{
    // Delegate.
    public delegate void RadiusChanged();

    public partial class Form1 : Form
    {
        private readonly CircleVizualizator _cv;
        private int _radius;

        public Form1()
        {
            InitializeComponent();

            // Create new Vizualizator.
            _cv = new CircleVizualizator(pictureBox1, new Circle(10));
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            // Attempt to parse text.
            if (!int.TryParse(textBox1.Text, out _radius) || _radius <= 0)
            {
                MessageBox.Show("Wrong format of input data");
                textBox1.Text = string.Empty;
                textBox1.Focus();
                return;
            }

            // Set radius.
            _cv.C.R = _radius;
        }

        private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
        {
            // Processing result.
            if (!checkBox4.Checked && !checkBox3.Checked)
                _cv.PenColor = Color.Black;
            if (checkBox3.Checked && !checkBox4.Checked)
                _cv.PenColor = Color.Red;
            else if (checkBox4.Checked && !checkBox3.Checked)
                _cv.PenColor = Color.Green;
            else if (checkBox4.Checked && checkBox3.Checked)
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                MessageBox.Show("Выберите что-то одно");
            }
        }

        private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
        {
            // Processing result.
            if (!checkBox4.Checked && !checkBox3.Checked)
                _cv.PenColor = Color.Black;
            if (checkBox3.Checked && !checkBox4.Checked)
                _cv.PenColor = Color.Red;
            else if (checkBox4.Checked && !checkBox3.Checked)
                _cv.PenColor = Color.Green;
            else if (checkBox4.Checked && checkBox3.Checked)
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                MessageBox.Show("Выберите что-то одно");
            }
        }
    }
}