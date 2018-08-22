using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.NPCs.Bosses
{
	public class UniversalMimic2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Universal Mimic");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BigMimicHallow];
		}

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 80;
			npc.damage = 500;
			npc.defense = 50;
			npc.lifeMax = 75000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 87;
			aiType = 87;
			animationType = NPCID.BigMimicHallow;
			music = MusicID.Boss1;
			npc.value = 999999f;
			npc.buffImmune[BuffID.Confused] = true;
			npc.npcSlots = 50f;
			npc.boss = true;
		}

		public override void NPCLoot()
	{

	if (Main.rand.Next(10) == 0)
	{
	Item.NewItem(npc.getRect(), mod.ItemType("UniversalMimicTrophy"));    
	}	


	if (Main.expertMode)
	{
    Item.NewItem(npc.getRect(), mod.ItemType("UniversalMimicBag"));        
	}
	else
	{
                Item.NewItem(npc.getRect(), mod.ItemType("CelestiteBar"), 30);
	}
	}

	}
}
