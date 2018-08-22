using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace InitiateMod
{
    public class InitiateWorld : ModWorld
    {
        private const int saveVersion = 0;
	public static bool downedEnchanter = false;
        public static int InitiateBlocks = 50;
	public static int PrehistoricSwamp = 0;

        public override void Initialize()
        {
	downedEnchanter = false;
        }

	public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedEnchanter) downed.Add("Enchanter");

			return new TagCompound {
				{"downed", downed}
			};
		}

        public override void Load(TagCompound tag)
        {
	var downed = tag.GetList<string>("downed");
	downedEnchanter = downed.Contains("Enchanter");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
	int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedEnchanter = flags[0];
			}
			else
			{
				ErrorLogger.Log("InitiateMod: Unknown loadVersion: " + loadVersion);
			}

        }

        public override void NetSend(BinaryWriter writer)
        {
	BitsByte flags = new BitsByte();
			flags[0] = downedEnchanter;
			writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
	BitsByte flags = reader.ReadByte();
			downedEnchanter = flags[0];
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            FirstModifyWorldGenTasks(tasks);
            SecondModifyWorldGenTasks(tasks);
        }
        public void FirstModifyWorldGenTasks(List<GenPass> tasks)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Prehistoric Swamp", delegate (GenerationProgress progress)
            {
                progress.Message = "Raising Prehistoric Swamp";
                int X = WorldGen.genRand.Next(1, Main.maxTilesX - 300);
                int firstY = WorldGen.genRand.Next((int)WorldGen.rockLayer, (int)WorldGen.rockLayer + 200);
                int Y = RaycastDown(X, firstY);
                for (int i = 0; i < Main.maxTilesX / 600; i++)
                {
                    WorldGen.TileRunner(X, Y, 300, WorldGen.genRand.Next(100, 200), mod.TileType("SwampGrass"), false, 0f, 0f, true, true);

                }
            }));
        }

        public int RaycastDown(int x, int y)
        {
            while (!Main.tile[x, y].active())
            {
                y++;
            }
            return y;
        }

        public void SecondModifyWorldGenTasks(List<GenPass> tasks)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Petrified Wood", delegate (GenerationProgress progress)
            {
                progress.Message = "Petrifying Wood";

                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), mod.TileType("PetrifiedWoodBlock"), false, 0f, 0f, false, true);
                }
            }));



        }
	public override void TileCountsAvailable(int[] tileCounts)
        {
            PrehistoricSwamp = tileCounts[mod.TileType("SwampGrass")];
        }



    }
}
