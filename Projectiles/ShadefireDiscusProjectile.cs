using Terraria.ModLoader;

namespace InitiateMod.Projectiles
{
	public class ShadefireDiscusProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(106);

			aiType = 106;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadefire Discus");

		}

	}
}
