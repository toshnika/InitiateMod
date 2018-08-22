using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PetrifiedWoodHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 24;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PetrifiedWoodChestpiece") && legs.type == mod.ItemType("PetrifiedWoodGreaves");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+50% Melee Speed";
			player.meleeSpeed *= 1.50f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PetrifiedWoodBlock", 25);
			recipe.AddIngredient(null, "SoulOfPlight", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}