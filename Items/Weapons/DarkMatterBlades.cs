using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class DarkMatterBlades : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Blades");
			Tooltip.SetDefault("");
		}


		public override void SetDefaults()
		{

			item.damage = 540;
			item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.consumable = false;
			item.height = 30;
			item.useTime = 3;
			item.useAnimation = 3;
			item.shoot = mod.ProjectileType("DarkMatterBladesProjectile");
			item.shootSpeed = 3f;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 7;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkMatter", 14);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}
