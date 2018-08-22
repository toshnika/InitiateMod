using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.NPCs.Bosses.DestroyerOfWorlds;

namespace InitiateMod.Items.Misc
{
	public class LuminiteWorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luminite Worm");
			Tooltip.SetDefault("Summons the destroyer of worlds");
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
            return Main.hardMode && NPC.downedMoonlord && !NPC.AnyNPCs(mod.NPCType<DOWHead>());
		}

		public override bool UseItem(Player player)
		{
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType<DOWHead>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFlight, 10);
           		recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}