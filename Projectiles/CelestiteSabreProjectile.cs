using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Projectiles
{
	public class CelestiteSabreProjectile : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestite Sabrebeam");

		}		
	
		public override void SetDefaults()
		{

			projectile.width = 26;
			projectile.height = 20;
			projectile.aiStyle = 27;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 600;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}


		public override Color? GetAlpha(Color lightColor)
		{
			return Color.Purple;
		}


	}
}