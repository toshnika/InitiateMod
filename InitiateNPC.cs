using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.Items.Misc;

namespace InitiateMod
{
	public class InitiateNPC : GlobalNPC
	{
		
		public override void NPCLoot (NPC npc)
		{
		
			if (npc.type == NPCID.ChaosElemental)
				{
					if (Main.rand.NextBool(40))
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DiscordianRing"));
				}
		
		}
	}
}