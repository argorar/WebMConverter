using System.Drawing;

namespace WebMConverter.Objects
{
    public class CropPoint
    {
        public decimal InitialTime { get; set; }
        public string Crop { get; set; }
        public RectangleF Rectangle { get; set; }

        public CropPoint(decimal initialTime, string crop, RectangleF rectangle)
        {
            InitialTime = initialTime;
            Crop = crop;
            Rectangle = rectangle;
        }
    }
}
