using Terraria;
using Terraria.ModLoader;
using InitiateMod;


namespace InitiateMod.StatusEffects
{
	public class MeganeuraPet : ModBuff
	{
		public override void SetDefaults()
		{
			
			DisplayName.SetDefault("Pet Meganeura");
			Description.SetDefault("So cute? or deadly");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<InitiatePlayer>(mod).MeganeuraPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("MeganeuraPetProjectile")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("MeganeuraPetProjectile"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}