using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Projectiles
{
	public class DarkMatterBladesProjectile : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark matter blade");

		}

		public override void SetDefaults()
		{

			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.aiStyle = 1;
			projectile.timeLeft = 1200;
			projectile.penetrate = 3;
			projectile.tileCollide = true; 
		}

		
	}
}
