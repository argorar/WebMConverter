namespace WebMConverter.Objects
{
    public class CropPoint
    {
        public decimal InitialTime { get; set; }
        public string Crop { get; set; }

        public CropPoint(decimal initialTime, string crop)
        {
            InitialTime = initialTime;
            Crop = crop;
        }
    }
}
