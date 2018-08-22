using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
    public class CosmicCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Core");
            Tooltip.SetDefault("A core of the cosmos"
                    + "\n+5 life regen");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 9;
            item.expert = true;
            item.accessory = true;
            item.lifeRegen += 5;
            item.manaIncrease += 5;
        }



    }
}
	