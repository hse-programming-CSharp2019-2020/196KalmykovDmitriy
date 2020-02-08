﻿using System;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Form1 : Form
    {
        private string _result;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Text = "Form1_Activated";
            _result += "\r\nActivated";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Form1_Load";
            _result += "\r\nLoad";
            MessageBox.Show("Event Load");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            Text = "Form1_Deactivate";
            _result += "\r\nDeactivate";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Text = "Form1_Resize";
            _result += "\r\nResize";
            MessageBox.Show("Event Resize");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Text = "Form1_Paint";
            _result += "\r\nPaint";
            MessageBox.Show("Event Paint");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Text = "Form1_FormClosed";
            _result = "События в жизни формы: " + _result;
            MessageBox.Show(_result + "\r\nFormClosed");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Text = "Form1_FormClosing";
            _result += "\r\nFormClosing";
            MessageBox.Show("Event FormClosing");
        }
    }
}
