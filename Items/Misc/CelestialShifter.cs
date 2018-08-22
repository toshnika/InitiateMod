using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Misc
{
	public class CelestialShifter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial Shifter");
			Tooltip.SetDefault("Shifts Time");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 1;
			item.rare = 4;
			item.useStyle = 4;
			item.useAnimation = 45;
			item.useTime = 45;
			item.UseSound = SoundID.Item44;
			item.consumable = false;
		}

		public override bool UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				if (Main.dayTime)
				{
					Main.time = 54000;
				}
				else
				{
					Main.time = 32400;
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(MessageID.WorldData);
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CelestiteBar", 5);
			recipe.AddIngredient(ItemID.Timer1Second, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}