using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class DarkEnergyStaff : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Energy Staff");
			Tooltip.SetDefault("");
		}		

		public override void SetDefaults()
		{

			item.damage = 1020;
			item.summon = true;
			item.mana = 10;
			item.width = 40;
			item.height = 40;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			Item.staff[item.type] = true; 
			item.shoot = mod.ProjectileType("DarkBee2");
			item.shootSpeed = 8f;
		}

		

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkMatter", 16);
			recipe.AddTile(null, "DarkEnergyReactor");
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
