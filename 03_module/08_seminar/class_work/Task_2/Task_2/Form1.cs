using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Task_2
{
    public partial class QueueForm : Form
    {
        private readonly ElectronicQueue<Person> _eq;

        public QueueForm()
        {
            InitializeComponent();

            // Create queue.
            _eq = new ElectronicQueue<Person>(); 

            #region Example.

            //eq.AddToElectronicQueue(new Person("Jabba", "Hutt", 604));
            //eq.AddToElectronicQueue(new Person("Wedge", "Antille", 25));
            //eq.AddToElectronicQueue(new Person("Han", "Solo", 33));
            //eq.AddToElectronicQueue(new Person("Leia", "Organa", 23));
            //eq.AddToElectronicQueue(new Person("Lando", "Calrissian", 35));
            //eq.AddToElectronicQueue(new Person("Anakin", "Skywalker", 46));

            #endregion
        }

        // Auxiliary variables for check data.
        private const string Pattern = @"^[A-Z|А-Я][a-z|а-я]*";
        private readonly Regex _regex = new Regex(Pattern);

        /// <summary>
        /// Check name for correctness.
        /// </summary>
        /// <returns> True or false </returns>
        private bool FirstNameIsCorrect() =>
                NameTextBox.Text != null && Regex.IsMatch(NameTextBox.Text, Pattern) &&
                _regex.Match(NameTextBox.Text).Length == NameTextBox.Text.Length;

        /// <summary>
        /// Check surname for correctness.
        /// </summary>
        /// <returns> True or false </returns>
        private bool LastNameIsCorrect() =>
                SurnameTextBox.Text != null && Regex.IsMatch(SurnameTextBox.Text, Pattern) &&
                _regex.Match(SurnameTextBox.Text).Length == SurnameTextBox.Text.Length;

        /// <summary>
        /// Check age for correctness.
        /// </summary>
        /// <returns> True or false </returns>
        private bool AgeIsCorrect() =>
            int.TryParse(AgeTextBox.Text, out var result) && result > 0;

        private void AddToQueueButton_Click(object sender, EventArgs e)
        {
            if (!FirstNameIsCorrect() || !LastNameIsCorrect() || !AgeIsCorrect())
                return;

            _eq.AddToElectronicQueue(new Person(NameTextBox.Text,
                SurnameTextBox.Text, int.Parse(AgeTextBox.Text)));

            NameTextBox.Clear();
            SurnameTextBox.Clear();
            AgeTextBox.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_eq.Length == 0)
                timer1.Enabled = false;

            QueueLabel.Text = _eq.CallFromElectronicQueue();
            System.Media.SystemSounds.Exclamation.Play();

            // Update the queue.
            _eq.DeleteFromElectronicQueue();
        }

        private void ShowQueueButton_Click(object sender, EventArgs e)=>
            timer1.Enabled = true;
    }
}
