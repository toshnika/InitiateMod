using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod;

namespace InitiateMod.Projectiles.Minions
{
	public class CelestiteSeekerStaffProjectile : Minion
	{

		 public override void SetStaticDefaults()
   		 {
     		 DisplayName.SetDefault("Celestite Seeker");
   		 }

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(388);
           		aiType = 388;
			projectile.width = 36;
			projectile.height = 24;
			Main.projFrames[projectile.type] = 1;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.timeLeft = 9999;
           		projectile.tileCollide = false;
               
		}

   

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = oldVelocity.Y;
				}
      return false;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			InitiatePlayer modPlayer = (InitiatePlayer)player.GetModPlayer(mod, "InitiatePlayer");
			if (player.dead)
			{
				modPlayer.CelestiteSeeker = false;
			}
			if (modPlayer.CelestiteSeeker)
			{
				projectile.timeLeft = 2;
			}
		}

	}
}
