using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class CelestiteStaff : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestite Staff");
			Tooltip.SetDefault("");
		}		

		public override void SetDefaults()
		{

			item.damage = 280;
			item.magic = true;
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 13800;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			Item.staff[item.type] = true; 
			item.shoot = mod.ProjectileType("CelestiteStaffProjectile");
			item.shootSpeed = 8f;
		}

		

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CelestiteBar", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
