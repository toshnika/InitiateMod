using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace InitiateMod.Items.Weapons
{
	public class EnchantersLegacy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanter's Legacy");
			Tooltip.SetDefault("The Enchanter's tome");
		}

		public override void SetDefaults()
		{
			item.damage = 60;
			item.noMelee = true;
			item.magic = true;
			item.mana = 8;
			item.rare = 5;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
            item.autoReuse = true;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("friendlyrazorblast");
			item.value = Item.sellPrice(silver: 3);
		}

	}
}
