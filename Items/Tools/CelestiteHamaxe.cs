using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Tools
{
	public class CelestiteHamaxe : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestite Hamaxe");
			Tooltip.SetDefault("");
		}
		

		public override void SetDefaults()
		{

			item.damage = 120;
			item.melee = true;
			item.width = 54;
			item.height = 48;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 20000;
			item.rare = 3;
			item.axe = 14;
			item.hammer = 180;
			item.UseSound = SoundID.Item1;
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
