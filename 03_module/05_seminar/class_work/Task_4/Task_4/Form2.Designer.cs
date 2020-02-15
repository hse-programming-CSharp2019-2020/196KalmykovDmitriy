namespace Task_4
{
    partial class Form2
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SampleSize = new System.Windows.Forms.Label();
            this.Average = new System.Windows.Forms.Label();
            this.xMin = new System.Windows.Forms.Label();
            this.xMax = new System.Windows.Forms.Label();
            this.ASD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SampleSize
            // 
            this.SampleSize.AutoSize = true;
            this.SampleSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SampleSize.Location = new System.Drawing.Point(81, 63);
            this.SampleSize.Name = "SampleSize";
            this.SampleSize.Size = new System.Drawing.Size(107, 18);
            this.SampleSize.TabIndex = 0;
            this.SampleSize.Text = "SampleSize: ";
            // 
            // Average
            // 
            this.Average.AutoSize = true;
            this.Average.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Average.Location = new System.Drawing.Point(81, 102);
            this.Average.Name = "Average";
            this.Average.Size = new System.Drawing.Size(78, 18);
            this.Average.TabIndex = 1;
            this.Average.Text = "Average: ";
            // 
            // xMin
            // 
            this.xMin.AutoSize = true;
            this.xMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xMin.Location = new System.Drawing.Point(471, 63);
            this.xMin.Name = "xMin";
            this.xMin.Size = new System.Drawing.Size(53, 18);
            this.xMin.TabIndex = 2;
            this.xMin.Text = "xMin: ";
            // 
            // xMax
            // 
            this.xMax.AutoSize = true;
            this.xMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xMax.Location = new System.Drawing.Point(471, 113);
            this.xMax.Name = "xMax";
            this.xMax.Size = new System.Drawing.Size(57, 18);
            this.xMax.TabIndex = 3;
            this.xMax.Text = "xMax: ";
            // 
            // ASD
            // 
            this.ASD.AutoSize = true;
            this.ASD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ASD.Location = new System.Drawing.Point(83, 146);
            this.ASD.Name = "ASD";
            this.ASD.Size = new System.Drawing.Size(76, 18);
            this.ASD.TabIndex = 4;
            this.ASD.Text = "A. S. D.: ";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 237);
            this.ControlBox = false;
            this.Controls.Add(this.ASD);
            this.Controls.Add(this.xMax);
            this.Controls.Add(this.xMin);
            this.Controls.Add(this.Average);
            this.Controls.Add(this.SampleSize);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Characteristic\'s estimates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label SampleSize;
        internal System.Windows.Forms.Label Average;
        internal System.Windows.Forms.Label xMin;
        internal System.Windows.Forms.Label xMax;
        internal System.Windows.Forms.Label ASD;
    }
}