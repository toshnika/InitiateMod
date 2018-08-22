using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Tools
{
	public class CelestitePickaxe : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestite Pickaxe");
			Tooltip.SetDefault("");
		}		

		public override void SetDefaults()
		{

			item.damage = 120;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 3;
			item.useAnimation = 3;
			item.pick = 285;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 600;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.autoReuse = true;
			item.tileBoost += 4;
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
