using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class DarkMatterRepeater : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Repeater");
		}

		public override void SetDefaults()
		{

		

			item.ranged = true;
			item.width = 36;
			item.height = 24;

			item.useTime = 8;
			item.useAnimation = 8;
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 8f;
			item.useStyle = 5;
			item.damage = 500;
			item.knockBack = 4;
			item.value = 30000;
			item.rare = 8;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkMatter", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}	

		
	}
}
