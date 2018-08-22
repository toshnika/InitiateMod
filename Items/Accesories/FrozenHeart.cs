using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Accesories
{
    public class FrozenHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Heart");
            Tooltip.SetDefault("+20% damage reduction"
                    + "\n-2 life regen");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 5;
            item.accessory = true;
            item.defense = 8;
            item.lifeRegen -= 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
            {

            player.endurance += 0.2f;

           }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IceBone", 6);
            recipe.AddIngredient(null, "FrozenBlood", 12);
            recipe.AddTile(TileID.IceMachine);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
	