using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class DarkMatterStaff : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Staff");
			Tooltip.SetDefault("");
		}		

		public override void SetDefaults()
		{

			item.damage = 660;
			item.summon = true;
			item.mana = 10;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			Item.staff[item.type] = true; 
			item.shoot = mod.ProjectileType("DarkBee");
			item.shootSpeed = 10f;
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
