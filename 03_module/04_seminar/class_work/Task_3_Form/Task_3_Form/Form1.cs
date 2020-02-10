using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Task_3_Form
{
    // Как вариант, везде можно было написать
    // универсальное считывание, как в консоли.

    // Delegates.
    internal delegate void ChainLenChanged(double r);
    internal delegate void ChainNChanged(int amount, double len, List<Bead> beads);
    internal delegate void ChainRChanged(double r);

    public partial class Form1 : Form
    {
        // Chain.
        private readonly Chain _ch = new Chain(800, 10);

        // Pen for drawing.
        private readonly Pen _pen = new Pen(Color.Magenta, 1);

        // Primary value of chain.
        private int _amount = 10;
        private double _length = 800;
        private double _rad;

        public Form1() =>
            InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            _ch.ChainLenChangedEvent += _ch.ChangeLen;
            _ch.ChainNChangedEvent += new Bead(10).ChangeN;
            _ch.ChainRChangedEvent += _ch.ChangeR;

            textBox1.Text = "10";
            textBox2.Text = "800";
            textBox3.Text = "80";
        }

        /// <summary>
        /// Draw full chain.
        /// </summary>
        /// <param name="r"> Radius of bead </param>
        /// <param name="amount"> Amount of beads </param>
        private void DrawChain(double r, int amount)
        {
            pictureBox1.Refresh();

            for (var i = 0; i < amount; i++)
                pictureBox1.CreateGraphics().DrawEllipse(_pen,
                    (float)(r * i), 50, (float)r, (float)r);
        }

        /// <summary>
        /// Draw full chain when clicked.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        private void button4_Click(object sender, EventArgs e) =>
            DrawChain(_ch.Beads[0].R, _ch.N);

        /// <summary>
        /// Processing amount of beads.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out _amount) || _amount <= 0)
                changeAmountButton.Enabled = false;
            else
                changeAmountButton.Enabled = true;
        }

        /// <summary>
        /// Processing length of chain.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox2.Text, out _length) || _length <= 0)
                changeLengthButton.Enabled = false;
            else
                changeLengthButton.Enabled = true;
        }

        /// <summary>
        /// Processing radius of bead.
        /// </summary>
        /// <param name="sender"> Sender </param>
        /// <param name="e"> E </param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox3.Text, out _rad) || _rad <= 0)
                changeRadiusButton.Enabled = false;
            else
                changeRadiusButton.Enabled = true;
        }


        private void changeAmountButton_Click(object sender, EventArgs e)
        {
            _ch.N = _amount;

            textBox2.Text = _ch.Len.ToString(CultureInfo.CurrentCulture);
            textBox3.Text = _ch.Beads[0].R.ToString(CultureInfo.CurrentCulture);
        }

        private void changeLengthButton_Click(object sender, EventArgs e)
        {
            _ch.Len = _length;

            textBox1.Text = _ch.N.ToString();
            textBox3.Text = _ch.Beads[0].R.ToString(CultureInfo.CurrentCulture);
        }

        private void changeRadiusButton_Click(object sender, EventArgs e)
        {
            _ch.ChangeRWithEvent(_rad);

            textBox1.Text = _ch.N.ToString();
            textBox2.Text = _ch.Len.ToString(CultureInfo.CurrentCulture);
        }
    }
}
