using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class PetrifiedStaff : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Petrified Staff");
			Tooltip.SetDefault("");
		}		

		public override void SetDefaults()
		{

			item.damage = 60;
			item.summon = true;
			item.mana = 10;
			item.width = 40;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			Item.staff[item.type] = true; 
			item.shoot = mod.ProjectileType("PetrifiedBee");
			item.shootSpeed = 18f;
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
