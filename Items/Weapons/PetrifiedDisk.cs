using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class PetrifiedDisk : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petrified Disk");
			Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useStyle = 1;

			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("PetrifiedDiskProjectile");
			item.damage = 59;
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
			recipe.AddIngredient(null, "PetrifiedWoodBlock", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}		

	}
}
