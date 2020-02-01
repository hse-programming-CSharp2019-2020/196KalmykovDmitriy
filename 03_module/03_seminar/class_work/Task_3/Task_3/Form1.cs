using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        // Variable for random.
        private static readonly Random Rnd = new Random();
        private static int _counter;

        public Form1()
        {
            InitializeComponent();

            // Add require handlers to the events.
            MouseEnter += (sender, e) => Text = "My Form " + _counter++;
            MouseClick += (sender, e) => BackColor = Color.Red;
            MouseEnter += (sender, e) => BackColor = DefaultBackColor;

            // Change size of form when clicked twice.
            MouseDoubleClick += (sender, e) =>
            {
                Width = Rnd.Next(100, 1001);
                Height = Rnd.Next(100, 1001);
            };
        }
    }
}