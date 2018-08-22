using InitiateMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class DiseasedHive : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Diseased Hive");
            Tooltip.SetDefault("Diseased with a plauge from a calamitous tyrant's jungle");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BeeKeeper);
			item.damage = 40;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BeeKeeper);
			recipe.AddTile(null, "PlagueInfuser");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(target.Center, target.velocity, mod.ProjectileType("plaguebee"), 30, 5, Main.myPlayer, 0f, 0f);
        }
	}
}

