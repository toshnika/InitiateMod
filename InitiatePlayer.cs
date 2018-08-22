using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using InitiateMod;
using InitiateMod.Blocks;
using InitiateMod.StatusEffects;

namespace InitiateMod
{
	public class InitiatePlayer : ModPlayer
	{
		private const int saveVersion = 0;
		public bool razorskiss = false;
       		public bool MeganeuraPet = false;
		public bool PrehistoricSwamp = false;
		public bool CelestiteSeeker = false;
		public bool extraAccessory2 = false;
		public bool jeweledCross = false;
		public override void ResetEffects()
		{
			razorskiss = false;
			MeganeuraPet = false;
			CelestiteSeeker = false;
			jeweledCross = false;
			if (extraAccessory2)
			{
				player.extraAccessorySlots += 1;
			}
		}
		
        public override void UpdateBadLifeRegen()
        {
            if (razorskiss)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
            }
           
        }

	public override TagCompound Save()
		{
			TagCompound tag = new TagCompound();
			tag["extraAccessory2"] = extraAccessory2;
			return tag;
		}

		public override void Load(TagCompound tag)
		{
			extraAccessory2 = tag.GetBool("extraAccessory2");
		}

	public override void UpdateBiomes()
        {
           PrehistoricSwamp = (InitiateWorld.PrehistoricSwamp > 0);    
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
	{

	player.immuneTime = player.longInvince ? 220 : 120;
	if (jeweledCross)
				{
					player.immuneTime += 100;
				}
            return false;

	}	

	}
}
