using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.Projectiles;

namespace InitiateMod.NPCs.Bosses
{
	public class Enchanter : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanter"); 
			Main.npcFrameCount[npc.type] = 6; 
		}

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = -1; 
			npc.damage = 45;
			npc.defense = 20;
			npc.lifeMax = 16000;
			npc.knockBackResist = 0f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.npcSlots = 50f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			music = MusicID.Boss1;
			npc.value = 9999f;
			npc.buffImmune[BuffID.Confused] = true;
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
        const int State_Razorblast = 2;
        const int State_Razorblast2 = 3;

		
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

            Player player = Main.player[npc.target];
			
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
						AI_State = State_Razorblast;
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

			else if (AI_State == State_Razorblast)
			{
				AI_Timer++;
				if (AI_Timer == 1)
				{
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: 5, SpeedY: -5, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: -5, SpeedY: 5, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: -5, SpeedY: -5, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
		    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: 5, SpeedY: 5, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
				}
				else if (AI_Timer > 40)
				{
					
                    AI_State = State_Razorblast2;
					AI_Timer = 0;
				}
			}

            else if (AI_State == State_Razorblast2)
            {
                AI_Timer++;
                if (AI_Timer == 1)
                {
             
			
		    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: 5, SpeedY: 0, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: 0, SpeedY: -5, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: -5, SpeedY: 0, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, SpeedX: 0, SpeedY: 5, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f, ai0: npc.whoAmI);
			
			if (Main.expertMode)
			{
				Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center);
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, Type: mod.ProjectileType("razorblast2"), Damage: 40, KnockBack: 2f);
			}
		    
                }
                else if (AI_Timer > 40)
                {

                    AI_State = State_En_Garde;
                    AI_Timer = 0;
                }
            }
	}
	
	public override void NPCLoot()
	{
	
	if (!InitiateWorld.downedEnchanter)
			{
				InitiateWorld.downedEnchanter = true;
				if (Main.netMode == NetmodeID.Server)
				NetMessage.SendData(MessageID.WorldData);
				Main.NewText("The swamps of the world tremble...", 100, 255, 20); 
			}

	if (Main.rand.Next(10) == 0)
	{
	Item.NewItem(npc.getRect(), mod.ItemType("EnchanterTrophy"));    
	}	

	
	if (Main.expertMode)
	{
    Item.NewItem(npc.getRect(), mod.ItemType("EnchanterBag"));        
	}
	else
	{
	Item.NewItem(npc.getRect(), mod.ItemType("EnchantersLegacy"));
	}

	}

	public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + name;
			potionType = ItemID.RestorationPotion;
		}
	
    }
}
