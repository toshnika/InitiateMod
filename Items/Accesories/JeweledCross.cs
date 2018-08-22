using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
	public class JeweledCross : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Greatly increases length of invincibility after taking damage");
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 24;
			item.accessory = true;
			item.rare = 11;
			item.value = Item.sellPrice(0, 25, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			InitiatePlayer modPlayer = player.GetModPlayer<InitiatePlayer>(mod);
			modPlayer.jeweledCross = true;
			player.longInvince = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrossNecklace);
			recipe.AddIngredient(ItemID.Amethyst);
			recipe.AddIngredient(ItemID.Topaz);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddIngredient(ItemID.Emerald);
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddIngredient(ItemID.Amber);
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddIngredient(ItemID.ChlorophyteOre);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}