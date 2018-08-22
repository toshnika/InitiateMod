using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Weapons
{
	public class DarkMatterWand : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Wand");
			Tooltip.SetDefault("Right Click to fire Dark Blasts");
		}		

		public override void SetDefaults()
		{

			item.damage = 410;
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
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			Item.staff[item.type] = true; 
			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("FriendlyLightBlast");

		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.damage = 410;
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 13800;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			Item.staff[item.type] = true; 
			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("FriendlyDarkBlast");
			}
			else
			{
				item.damage = 410;
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
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			Item.staff[item.type] = true; 
			item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("FriendlyLightBlast");
			}
			return base.CanUseItem(player);
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarkMatter", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
