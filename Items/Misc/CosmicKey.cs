using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
// If you are using c# 6, you can use: "using static Terraria.Localization.GameCulture;" which would mean you could just write "DisplayName.AddTranslation(German, "");"
using Terraria.Localization;

namespace InitiateMod.Items.Misc
{
	public class CosmicKey : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Charged with the essence of the cosmos");

		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 6);
            		recipe.AddIngredient(ItemID.FragmentStardust, 6);
           		recipe.AddIngredient(ItemID.FragmentSolar, 6);
			recipe.AddIngredient(ItemID.FragmentVortex, 6);
            		recipe.AddIngredient(ItemID.FragmentNebula, 6);
			recipe.AddIngredient(ItemID.DirtBlock, 20);
			recipe.AddIngredient(ItemID.LivingFireBlock, 20);
			recipe.AddIngredient(ItemID.Cloud, 20);
			recipe.AddIngredient(ItemID.WaterBucket, 1);
            		recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
