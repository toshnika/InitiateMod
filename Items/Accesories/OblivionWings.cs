using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
	[AutoloadEquip(EquipType.Wings)]
	public class OblivionWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fueled by oblivion annihilation between dark and light particles");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 9;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 400;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.90f;
			ascentWhenRising = 0.30f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 20f;
			acceleration *= 6f;
		}
	}
}