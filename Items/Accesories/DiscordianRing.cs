using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
    public class DiscordianRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Discordian Ring");
            Tooltip.SetDefault("Charged with the essence of chaos"
                    + "\nPrevents Chaos State");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 9;
            item.accessory = true;
        }

	public override void UpdateAccessory(Player player, bool hideVisual)

		{	
            player.buffImmune[BuffID.ChaosState] = true;

		}

    }
}
	