using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Projectiles.Pets
{
	public class MeganeuraPetProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meganeura"); // Automatic from .lang files
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			InitiatePlayer modPlayer = player.GetModPlayer<InitiatePlayer>(mod);
			if (player.dead)
			{
				modPlayer.MeganeuraPet = false;
			}
			if (modPlayer.MeganeuraPet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}