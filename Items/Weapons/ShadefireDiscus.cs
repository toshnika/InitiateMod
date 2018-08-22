using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class ShadefireDiscus : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadefire Discus");
			Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 1;

			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("ShadefireDiscusProjectile");
			item.damage = 32;
			item.width = 18;
			item.height = 20;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 14;
			item.useTime = 17;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 6000;
			item.knockBack = 4f;
			item.rare = 5;
			item.thrown = true;
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HellflameShadowspark", 7);
			recipe.AddIngredient(ItemID.CobaltBar, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HellflameShadowspark", 7);
			recipe.AddIngredient(ItemID.PalladiumBar, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}		

	}
}
