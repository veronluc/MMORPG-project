using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class EffectRegen : TileEffect
    {
        public int rateRegenVitality { get; set; }
        public int rateRegenMana { get; set; }
        public int goldCost { get; set; }

        public EffectRegen(int rateRegenVitality, int rateRegenMana, int goldCost)
        {
            this.rateRegenVitality = rateRegenVitality;
            this.rateRegenMana = rateRegenMana;
            this.goldCost = goldCost;
        }
    }
}
