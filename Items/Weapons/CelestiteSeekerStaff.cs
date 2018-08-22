using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class CelestiteSeekerStaff : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestite seeker staff");
			Tooltip.SetDefault("Summons a celestite seeker to fight for you.");
		}		

		public override void SetDefaults()
		{

			item.damage = 320;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("CelestiteSeekerStaffProjectile");
			item.shootSpeed = 2f;
			item.buffType = mod.BuffType("CelestiteSeeker");
			item.buffTime = 9999;
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
