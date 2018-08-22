using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Misc
{
	public class ThirdSealOfOblivion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Permanently increases the number of accessory slots by 1"
				+ "\nCan only be used if the Demon Heart has been used"
				+ "\nOnly usable once");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.maxStack = 20;
			item.rare = 11;
			item.expert = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.consumable = true;
			item.useStyle = 4;
			item.useTime = 15;
			item.useAnimation = 15;
			item.UseSound = SoundID.Item4;
		}

		public override bool CanUseItem(Player player)
		{
			InitiatePlayer modPlayer = player.GetModPlayer<InitiatePlayer>();
			return player.extraAccessory && !modPlayer.extraAccessory2;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<InitiatePlayer>().extraAccessory2 = true;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CelestiteBar", 10);
			recipe.AddIngredient(null, "OblivionEssence", 8);
			recipe.AddIngredient(ItemID.SoulofLight, 4);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}