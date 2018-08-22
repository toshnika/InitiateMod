using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HellshadeCowl : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+35% Thrown Damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.thrownDamage *= 1.35f;
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 3;
			item.defense = 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("HellshadeRobes");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+ 32% Throwing Crit";
			player.thrownCrit += 32;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(null, "HellflameShadowspark", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}