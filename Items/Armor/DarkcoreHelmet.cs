using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkcoreHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+200 max mana" 
 +"\n+20% crit chance"
 +"\n+35% melee speed"
 +"\n+6 max minions");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 50;
		}
		
		public override void UpdateEquip(Player player)
		{
            player.statManaMax2 += 200;
	    player.meleeCrit += 20;
            player.thrownCrit += 20;
            player.rangedCrit += 20;
            player.magicCrit += 20;
	    player.meleeSpeed *= 1.35f;
	    player.maxMinions += 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DarkcoreScalemail") && legs.type == mod.ItemType("DarkcoreLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+6 life regen"
+"\n+20% damage and crit chance";
			
		 	
            		player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.thrownDamage *= 1.2f;
            player.meleeCrit += 20;
            player.rangedCrit += 20;
            player.thrownCrit += 20;
            player.magicCrit += 20;
			player.lifeRegen += 6;
            
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DestroyerScale", 20);
			recipe.AddIngredient(null, "DarkMatter", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}