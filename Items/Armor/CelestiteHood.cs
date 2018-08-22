using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CelestiteHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+2 life regen");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 18;
		}
		
		public override void UpdateEquip(Player player)
		{
            player.lifeRegen += 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("CelestiteBodyarmour") && legs.type == mod.ItemType("CelestiteLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+15% magic damage"
					+"\n-20% mana usage";
            		player.magicDamage *= 1.15f;
            player.manaCost *= 0.8f;
            		
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CelestiteBar", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}