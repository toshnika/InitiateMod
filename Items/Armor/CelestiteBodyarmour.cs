using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CelestiteBodyarmour : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Celestite Bodyarmour");
			Tooltip.SetDefault("+20% Damage"
					+ "\n+100 Max life");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 46;
			
		}

		public override void UpdateEquip(Player player)
		{
            player.meleeDamage *= 1.2f;
            player.thrownDamage *= 1.2f;
            player.rangedDamage *= 1.2f;
            player.magicDamage *= 1.2f;
            player.minionDamage *= 1.2f;
            player.statLifeMax2 += 100;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CelestiteBar", 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}