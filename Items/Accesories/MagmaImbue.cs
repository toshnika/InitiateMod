using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
    public class MagmaImbue : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Imbue");
            Tooltip.SetDefault("Melee attacks inflict flame"
                    + "\n+10% melee damage");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 5;
	    item.expert = true;
            item.accessory = true;
            item.defense = 8;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
            {

            player.magmaStone = true;
	        player.meleeDamage *= 1.1f;

           }

     
    }
}
	