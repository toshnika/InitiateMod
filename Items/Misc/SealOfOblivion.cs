using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.NPCs.Bosses;

namespace InitiateMod.Items.Misc
{
	public class SecondSealOfOblivion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seal of Oblivion");
			Tooltip.SetDefault("Light and dark have been obliterated...");
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
            return Main.hardMode && NPC.downedMoonlord && !NPC.AnyNPCs(mod.NPCType<OblivionInitiate>());
		}

		public override bool UseItem(Player player)
		{
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType<OblivionInitiate>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CelestiteBar", 8);
			recipe.AddIngredient(ItemID.Amethyst, 4);
			recipe.AddIngredient(ItemID.SoulofLight, 4);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}