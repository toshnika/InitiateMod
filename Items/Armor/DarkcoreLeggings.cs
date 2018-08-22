using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DarkcoreLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("65% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 40;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.65f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DestroyerScale", 20);
			recipe.AddIngredient(null, "DarkMatter", 15);
			recipe.AddTile(null, "DarkEnergyReactor");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}