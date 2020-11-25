using System;

namespace AI12_DataObjects
{
    [Serializable()]
    public class EffectBarrier : TileEffect
    {
        public int PMrequired { get; set; }
        public bool passable { get; set; }

        public EffectBarrier()
        {

        }

        public EffectBarrier(int PMrequired, bool passable)
        {
            this.PMrequired = PMrequired;
            this.passable = passable;
        }
    }
}
