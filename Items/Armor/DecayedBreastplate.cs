using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DecayedBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Decayed Breastplate");
			Tooltip.SetDefault("Immune to poison");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Poisoned] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodBreastplate, 1);
			recipe.AddIngredient(ItemID.JungleShirt, 1);
			recipe.AddTile(null, "PlagueInfuser");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}