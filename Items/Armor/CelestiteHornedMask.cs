using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CelestiteHornedMask : ModItem
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
			player.setBonus = "+25% Summon damage"
					+"\n+4 max minions";
			
            		player.minionDamage *= 1.25f;
			player.maxMinions += 4;
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