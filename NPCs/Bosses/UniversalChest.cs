﻿using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace InitiateMod.NPCs.Bosses
{
	// Example Soul of Light/Soul of Night style NPC summon
	public class ExampleChestSummon : InitiatePlayer
	{
		public int LastChest = 0;

		// This doesn't make sense, but this is around where this check happens in Vanilla Terraria.
		public override void PreUpdateBuffs()
		{
			if (Main.netMode != 1)
			{
				if (player.chest == -1 && LastChest >= 0 && Main.chest[LastChest] != null)
				{
					int x2 = Main.chest[LastChest].x;
					int y2 = Main.chest[LastChest].y;
					ChestItemSummonCheck(x2, y2, mod);
				}
				LastChest = player.chest;
			}
		}

		public static bool ChestItemSummonCheck(int x, int y, Mod mod)
		{
			if (Main.netMode == 1)
			{
				return false;
			}
			int num = Chest.FindChest(x, y);
			if (num < 0)
			{
				return false;
			}
			int numberCosmicKeys = 0;
			int numberOtherItems = 0;
			ushort tileType = Main.tile[Main.chest[num].x, Main.chest[num].y].type;
			int tileStyle = (int)(Main.tile[Main.chest[num].x, Main.chest[num].y].frameX / 36);
			if (TileID.Sets.BasicChest[tileType] && (tileStyle < 5 || tileStyle > 6))
			{
				for (int i = 0; i < 40; i++)
				{
					if (Main.chest[num].item[i] != null && Main.chest[num].item[i].type > 0)
					{
						if (Main.chest[num].item[i].type == mod.ItemType("CosmicKey"))
						{
							numberCosmicKeys += Main.chest[num].item[i].stack;
						}
						else
						{
							numberOtherItems++;
						}
					}
				}
			}
			if (numberOtherItems == 0 && numberCosmicKeys == 1)
			{
				if (TileID.Sets.BasicChest[Main.tile[x, y].type])
				{
					if (Main.tile[x, y].frameX % 36 != 0)
					{
						x--;
					}
					if (Main.tile[x, y].frameY % 36 != 0)
					{
						y--;
					}
					int number = Chest.FindChest(x, y);
					for (int j = x; j <= x + 1; j++)
					{
						for (int k = y; k <= y + 1; k++)
						{
							if (Main.tile[j, k].type == 21)
							{
								Main.tile[j, k].active(false);
							}
						}
					}
					for (int l = 0; l < 40; l++)
					{
						Main.chest[num].item[l] = new Item();
					}
					Chest.DestroyChest(x, y);
					NetMessage.SendData(34, -1, -1, null, 1, (float)x, (float)y, 0f, number, 0, 0);
					NetMessage.SendTileSquare(-1, x, y, 3);
				}
				int npcToSpawn = mod.NPCType("UniversalMimic");
				int npcIndex = NPC.NewNPC(x * 16 + 16, y * 16 + 32, npcToSpawn, 0, 0f, 0f, 0f, 0f, 255);
				Main.npc[npcIndex].whoAmI = npcIndex;
				NetMessage.SendData(23, -1, -1, null, npcIndex, 0f, 0f, 0f, 0, 0, 0);
				Main.npc[npcIndex].BigMimicSpawnSmoke();
			}
			return false;
		}
	}
}
