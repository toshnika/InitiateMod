using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
    public class EnchantedMedalion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Medalion");
            Tooltip.SetDefault("An enchanted relic"
                    + "\n+3 life regen");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 9;
            item.expert = true;
            item.accessory = true;
            item.defense = 5;
            item.lifeRegen += 3;
        }



    }
}
	