using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PetrifiedWoodGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PetrifiedWoodBlock", 30);
			recipe.AddIngredient(null, "SoulOfPlight", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}