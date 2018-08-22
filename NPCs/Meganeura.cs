using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.NPCs
{
	public class Meganeura : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meganeura");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.FlyingFish];
		}

		public override void SetDefaults()
		{
			npc.width = 46;
			npc.height = 23;
			npc.damage = 45;
			npc.defense = 12;
			npc.lifeMax = 450;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 2000f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 44;
			aiType = 44;
			animationType = NPCID.FlyingFish;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileType == mod.TileType<Blocks.SwampGrass>() ? .1f : 0f;
        }

		public override void NPCLoot()
		{
            if (Main.rand.Next(30) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("MeganeuraPet"));
            }
		}


	}
}
