using System;

namespace WebMConverter
{
    public class LevelsFilter
    {
        public LevelsConversion Type { get; }

        public LevelsFilter(LevelsConversion type)
        {
            Type = type;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case LevelsConversion.TVtoPC:
                    return "ColorYUV(levels=\"TV->PC\")";
                case LevelsConversion.PCtoTV:
                    return "ColorYUV(levels=\"PC->TV\")";
                default:
                    throw new NotImplementedException();
            }
            
        }
    }

    public enum LevelsConversion
    {
        TVtoPC, // expanding to the full PC range
        PCtoTV  // fixing FRAPS videos
    }
}