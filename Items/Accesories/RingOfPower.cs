using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
    public class RingOfPower : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ring Of Power");
            Tooltip.SetDefault("Increased life regen and decreased health potion cooldown"
                    + "\nPrevents Chaos State"
		    + "\n+10% Damage");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 9;
            item.accessory = true;
 	    item.lifeRegen += 2;
        }

	public override void UpdateAccessory(Player player, bool hideVisual)

		{	
				player.buffImmune[BuffID.ChaosState] = true;
				player.pStone = true;
				player.meleeDamage *= 1.1f;
            	player.thrownDamage *= 1.1f;
           		player.rangedDamage *= 1.1f;
            	player.magicDamage *= 1.1f;
            	player.minionDamage *= 1.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DiscordianRing", 1);
			recipe.AddIngredient(ItemID.CharmofMyths);
			recipe.AddIngredient(ItemID.AvengerEmblem);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
}
	