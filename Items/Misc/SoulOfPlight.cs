using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Items.Misc
{
	public class SoulOfPlight : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of Plight");
			Tooltip.SetDefault("'The essence of ancient swamps'");
			// ticksperframe, frameCount
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		// TODO -- Velocity Y smaller, post NewItem?
		public override void SetDefaults()
		{
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			item.width = refItem.width;
			item.height = refItem.height;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 3;
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(item.Center, Color.Yellow.ToVector3() * 0.55f * Main.essScale);
		}
	}

	public class SoulGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<InitiatePlayer>(mod).PrehistoricSwamp)
			{
                if (Main.rand.Next(5) == 0){
                    if (InitiateWorld.downedEnchanter == true)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulOfPlight"), 1);
                    }
                    }
			}
		}
	}
}