using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class CelestiteRepeater : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestite Repeater");
		}

		public override void SetDefaults()
		{

		

			item.ranged = true;
			item.width = 36;
			item.height = 24;

			item.useTime = 9;
			item.useAnimation = 9;
			item.shoot = 1;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 9f;
			item.useStyle = 5;
			item.damage = 260;
			item.knockBack = 4;
			item.value = 30000;
			item.rare = 7;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
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
