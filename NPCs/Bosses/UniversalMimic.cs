using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.NPCs.Bosses;

namespace InitiateMod.NPCs.Bosses
{
	public class UniversalMimic : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Universal Mimic"); 
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = 75;
			npc.height = 75;
			npc.aiStyle = -1; 
			npc.damage = 60;
			npc.defense = 50;
			npc.lifeMax = 50000;
			npc.knockBackResist = 0f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.npcSlots = 50f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noTileCollide = false;
			music = MusicID.Boss1;
			npc.value = 0f;
			npc.buffImmune[BuffID.Confused] = true;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

	

		const int AI_State_Slot = 0;
		const int AI_Timer_Slot = 1;
		const int AI_Flutter_Time_Slot = 2;
		const int AI_Unused_Slot_3 = 3;

		
		const int Local_AI_Unused_Slot_0 = 0;
		const int Local_AI_Unused_Slot_1 = 1;
		const int Local_AI_Unused_Slot_2 = 2;
		const int Local_AI_Unused_Slot_3 = 3;

		
		const int State_En_Garde = 0;
		const int State_Notice = 1;
        	const int State_ShadowBeam = 2;

		
		public float AI_State
		{
			get { return npc.ai[AI_State_Slot]; }
			set { npc.ai[AI_State_Slot] = value; }
		}

		public float AI_Timer
		{
			get { return npc.ai[AI_Timer_Slot]; }
			set { npc.ai[AI_Timer_Slot] = value; }
		}

		public float AI_FlutterTime
		{
			get { return npc.ai[AI_Flutter_Time_Slot]; }
			set { npc.ai[AI_Flutter_Time_Slot] = value; }
		}

		

		public override void AI()
		{
			
			if (AI_State == State_En_Garde)
			{
				
				npc.TargetClosest(true);

				if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 1000f)
				{

					AI_State = State_Notice;
					AI_Timer = 0;
				}
			}

			else if (AI_State == State_Notice)
			{

				if (Main.player[npc.target].Distance(npc.Center) < 800f)
				{
	
					AI_Timer++;
					if (AI_Timer >= 20)
					{
						AI_State = State_ShadowBeam;
						AI_Timer = 0;
					}
				}
				else
				{
					npc.TargetClosest(true);
					if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 800f)
					{

						AI_State = State_En_Garde;
						AI_Timer = 0;
					}
				}
			}

			else if (AI_State == State_ShadowBeam)
			{
				AI_Timer++;
				if (AI_Timer == 1)
				{
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: 5, SpeedY: -5, Type: ProjectileID.ShadowBeamHostile, Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: -5, SpeedY: 5, Type: ProjectileID.ShadowBeamHostile, Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: -5, SpeedY: -5, Type: ProjectileID.ShadowBeamHostile, Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
		    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: 5, SpeedY: 5, Type: ProjectileID.ShadowBeamHostile, Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
		    NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType("Ragnarock"));
				}
				else if (AI_Timer > 40)
				{

                    AI_State = State_ShadowBeam;
					AI_Timer = 0;
				}
			}

	}

        public override void NPCLoot()
        {

            NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType("UniversalMimic2"));
           
        }

    }
}