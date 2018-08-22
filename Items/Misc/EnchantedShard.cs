using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.NPCs.Bosses;

namespace InitiateMod.Items.Misc
{
	public class EnchantedShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Shard");
			Tooltip.SetDefault("The power of an ancient entity rests in this artifact");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.value = 250000;
			item.rare = 1;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
            return Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3  && !NPC.AnyNPCs(mod.NPCType<Enchanter>());
		}

		public override bool UseItem(Player player)
		{
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType<Enchanter>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}