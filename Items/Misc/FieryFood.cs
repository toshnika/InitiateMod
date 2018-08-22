using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.NPCs.Bosses.Hellwurm;

namespace InitiateMod.Items.Misc
{
	public class FieryFood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fiery Food");
			Tooltip.SetDefault("Fiery food for a fiery wurm");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 100;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
            return Main.hardMode && !NPC.AnyNPCs(mod.NPCType<WormHead>());
		}

		public override bool UseItem(Player player)
		{
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType<WormHead>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.LivingFireBlock, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}