using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DecayedHelmet : ModItem
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
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DecayedBreastplate") && legs.type == mod.ItemType("DecayedLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+5% damage";
			player.meleeDamage *= 1.05f;
			player.thrownDamage *= 1.05f;
			player.rangedDamage *= 1.05f;
			player.magicDamage *= 1.05f;
			player.minionDamage *= 1.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodHelmet, 1);
			recipe.AddIngredient(ItemID.JungleHat, 1);
			recipe.AddTile(null, "PlagueInfuser");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}