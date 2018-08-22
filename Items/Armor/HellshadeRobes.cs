using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class HellshadeRobes : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Hellshade Robes");
			Tooltip.SetDefault("+4% Thrown Crit");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 14;
			
		}

		public override void UpdateEquip(Player player)
		{
            player.thrownCrit += 4;
		}

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
		{
			robes = true;
			// The equipSlot is added in ExampleMod.cs --> Load hook
			equipSlot = mod.GetEquipSlot("HellshadeRobes_Legs", EquipType.Legs);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 35);
			recipe.AddIngredient(null, "HellflameShadowspark", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}