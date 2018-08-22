using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.NPCs
{
	public class Ragnarock : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ragnarock");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.MeteorHead];
		}

		public override void SetDefaults()
		{
			npc.width = 20;
			npc.height = 20;
			npc.damage = 140;
			npc.defense = 24;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 14;
			aiType = 14;
			animationType = 14;
		}

	}
}
