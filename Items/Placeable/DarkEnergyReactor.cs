using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Placeable
{
	public class DarkEnergyReactor : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Used to create dark energy items");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 13;
			item.useTime = 13;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("DarkEnergyReactor");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkMatter", 18);
			recipe.AddIngredient(null, "CelestiteBar", 10);
			recipe.AddIngredient(null, "DestroyerScale", 10);
			recipe.AddIngredient(null, "OblivionEssence", 6);
			recipe.AddIngredient(ItemID.Furnace, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}