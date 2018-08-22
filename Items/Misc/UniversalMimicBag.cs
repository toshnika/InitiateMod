using Terraria;
using Terraria.ModLoader;

namespace InitiateMod.Items.Misc
{
	public class UniversalMimicBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("UniversalMimic2");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
            player.QuickSpawnItem(mod.ItemType("CelestiteBar"), 30);
			if (Main.rand.Next(2) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("BlackHole"));
			}
			else
			{
                player.QuickSpawnItem(mod.ItemType("CosmicCore"));
			}
			
		}
	}
}