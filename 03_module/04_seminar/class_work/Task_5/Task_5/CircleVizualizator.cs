using System.Drawing;
using System.Windows.Forms;

namespace Task_5
{
    internal class CircleVizualizator
    {
        public Circle C;

        // Some variable for drawing.
        public PictureBox Trg;
        private readonly Pen _pen = new Pen(Color.Black, 3);

        public CircleVizualizator(PictureBox pb, Circle c)
        {
            (Trg, C) = (pb, c);

            c.OnRadiusChanged += () =>
            {
                Trg.Refresh();
                Draw();
            };
        }

        /// <summary>
        /// Draw circle.
        /// </summary>
        private void Draw() =>
            Trg.CreateGraphics().DrawEllipse(_pen, 0, 0, C.R, C.R);

        // Property for pen's color.
        public Color PenColor
        {
            set => _pen.Color = value;
        }


    }
}
