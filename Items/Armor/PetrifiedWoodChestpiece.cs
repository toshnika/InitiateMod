using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class PetrifiedWoodChestpiece : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Petrified Wood Chestpiece");
			Tooltip.SetDefault("+10% Damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 32;
			
		}

		public override void UpdateEquip(Player player)
		{
            player.meleeDamage *= 1.1f;
            player.thrownDamage *= 1.1f;
            player.rangedDamage *= 1.1f;
            player.magicDamage *= 1.1f;
            player.minionDamage *= 1.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PetrifiedWoodBlock", 35);
			recipe.AddIngredient(null, "SoulOfPlight", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}