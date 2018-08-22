using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DecayedLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("5% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodGreaves, 1);
			recipe.AddIngredient(ItemID.JunglePants, 1);
			recipe.AddTile(null, "PlagueInfuser");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}