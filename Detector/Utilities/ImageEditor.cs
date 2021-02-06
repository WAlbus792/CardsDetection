using System;
using System.Drawing;

namespace Detector.Utilities
{
	/// <summary>
	/// Allows to add graphic elements to the existing image.
	/// </summary>
	public class ImageEditor : IDisposable
    {
        #region Fields

        private readonly string fontFamily;
        private readonly float fontSize;
        private readonly Graphics graphics;
        private readonly Image image;
        private readonly string outputFile;

        #endregion

        #region Constructors

        public ImageEditor(string inputFile, string outputFile, string fontFamily = "Ariel", float fontSize = 12)
        {
            if (string.IsNullOrEmpty(inputFile)) throw new ArgumentNullException(nameof(inputFile));

            if (string.IsNullOrEmpty(outputFile)) throw new ArgumentNullException(nameof(outputFile));

            this.fontFamily = fontFamily;
            this.fontSize = fontSize;
            this.outputFile = outputFile;

            image = Image.FromFile(inputFile);
            graphics = Graphics.FromImage(image);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            if (image != null)
            {
                image.Save(outputFile);

                graphics?.Dispose();

                image.Dispose();
            }
        }

        #endregion

        #region Methods

        #region Public methods

		/// <summary>
		/// Adds rectangle with a label in particular position of the image
		/// </summary>
		public void AddBox( float xmin, float xmax, float ymin, float ymax, string text = "", string colorName = "darkgreen")
        {
            float left = xmin * image.Width;
            float right = xmax * image.Width;
            float top = ymin * image.Height;
            float bottom = ymax * image.Height;

            Rectangle imageRectangle = new Rectangle(new Point(0, 0), new Size(image.Width, image.Height));
            graphics.DrawImage(image, imageRectangle);

            Color color = Color.FromName(colorName);
            Brush brush = new SolidBrush(color);
            Pen pen = new Pen(brush, 3);

            graphics.DrawRectangle(pen, left, top, right - left, bottom - top);
            Font font = new Font(fontFamily, fontSize);
            SizeF size = graphics.MeasureString(text, font);
            graphics.DrawString(text, font, brush, new PointF(left, top - size.Height));
        }

        #endregion

        #endregion
    }
}