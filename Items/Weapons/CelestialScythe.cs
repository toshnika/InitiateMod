using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class CelestialScythe : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestite Scythe");
			Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 1;

			item.shootSpeed = 14f;
			item.shoot = mod.ProjectileType("CelestiteScytheProjectile");
			item.damage = 216;
			item.width = 18;
			item.height = 20;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 14;
			item.useTime = 14;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 6000;
			item.knockBack = 5f;
			item.rare = 7;
			item.thrown = true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CelestiteBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}		

	}
}
