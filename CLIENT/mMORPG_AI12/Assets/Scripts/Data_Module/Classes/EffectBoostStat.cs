using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class EffectBoostStat : TileEffect
    {
        public int boostStrength { get; set; }
        public int boostIntelligence { get; set; }
        public int boostDefense { get; set; }

        public EffectBoostStat(int boostStrength, int boostIntelligence, int boostDefense)
        {
            this.boostStrength = boostStrength;
            this.boostIntelligence = boostIntelligence;
            this.boostDefense = boostDefense;
        }
    }
}
