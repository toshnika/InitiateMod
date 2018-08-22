using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class DarkcoreScalemail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Darkcore Scalemail");
			Tooltip.SetDefault("+25% Damage"
					+ "\n+250 Max life");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 60;
			
		}

		public override void UpdateEquip(Player player)
		{
            player.meleeDamage *= 1.25f;
            player.thrownDamage *= 1.25f;
            player.rangedDamage *= 1.25f;
            player.magicDamage *= 1.25f;
            player.minionDamage *= 1.25f;
            player.statLifeMax2 += 250;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DestroyerScale", 25);
			recipe.AddIngredient(null, "DarkMatter", 16);
			recipe.AddTile(null, "DarkEnergyReactor");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}