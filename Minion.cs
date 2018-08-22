using System;
using Terraria;
using Terraria.ModLoader;

namespace InitiateMod
{
    public abstract class Minion : ModProjectile
    {

	 public override void AI()
        {
            CheckActive();
        }

	        public abstract void CheckActive();
     
    }
}