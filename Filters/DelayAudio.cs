namespace WebMConverter
{
    public class DelayAudio
    {
        private readonly string valueDelay;

        public DelayAudio(string value)
        {
            valueDelay = value;
        }

        public override string ToString() => $"DelayAudio({valueDelay})";
    }
}
