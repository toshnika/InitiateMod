using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Pets
{
	public class MeganeuraPet : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			DisplayName.SetDefault("Tattered Dragonfly Wing");
			Tooltip.SetDefault("Summons a pet meganeura");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = mod.ProjectileType("MeganeuraPetProjectile");
			item.buffType = mod.BuffType("MeganeuraPet");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}