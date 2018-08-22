using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using InitiateMod.Projectiles;

namespace InitiateMod.NPCs.Bosses
{
    public class OblivionInitiate : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivion Initiate");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CultistBoss];
        }

    public override void SetDefaults()
    {
        npc.width = 18;
        npc.height = 40;
        npc.aiStyle = -1; 
        npc.damage = 450;
        npc.defense = 56;
        npc.lifeMax = 320000;
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
        npc.buffImmune[BuffID.Ichor] = true;
        npc.buffImmune[BuffID.CursedInferno] = true;
        npc.buffImmune[BuffID.OnFire] = true;
        npc.buffImmune[BuffID.ShadowFlame] = true;
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
    const int AI_Unused_Slot_4 = 4;
    const int AI_Unused_Slot_5 = 5;


    const int Local_AI_Unused_Slot_0 = 0;
    const int Local_AI_Unused_Slot_1 = 1;
    const int Local_AI_Unused_Slot_2 = 2;
    const int Local_AI_Unused_Slot_3 = 3;
    const int Local_AI_Unused_Slot_4 = 4;
    const int Local_AI_Unused_Slot_5 = 5;


    const int State_En_Garde = 0;
    const int State_Notice = 1;
    const int State_Oblast = 2;
    const int State_Minions = 3;
    const int State_Minions2 = 4;
    const int State_Teleport = 5;

    
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

            if (Main.player[npc.target].Distance(npc.Center) < 3000f)
            {

                AI_Timer++;
                if (AI_Timer >= 20)
                {
                    AI_State = State_Oblast;
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

        else if (AI_State == State_Oblast)
        {
            AI_Timer++;
            if (AI_Timer == 1)
            {
                Vector2 velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, Type: mod.ProjectileType("LightBlast"), Damage: 135, KnockBack: 4f);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, Type: mod.ProjectileType("DarkBlast"), Damage: 150, KnockBack: 7f);
            }
            else if (AI_Timer > 40)
            {

                AI_State = State_Minions;
                AI_Timer = 0;
            }
        }

        else if (AI_State == State_Minions)
        {
            AI_Timer++;
            if (AI_Timer == 1)
            {

                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, NPCID.Pixie);
                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, NPCID.Corruptor);

            }
            else if (AI_Timer > 40)
            {
                if (Main.rand.Next(10) == 0)
                {
                    AI_State = State_Minions2;
                }
                else
                {
                    AI_State = State_En_Garde;
                }

                AI_Timer = 0;
            }
        }


        else if (AI_State == State_Minions2)
        {
            AI_Timer++;
            if (AI_Timer == 1)
            {

                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, NPCID.BigMimicCrimson);
                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, NPCID.BigMimicCorruption);
                NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, NPCID.BigMimicHallow);

            }
            else if (AI_Timer > 40)
            {

                AI_State = State_Teleport;

                AI_Timer = 0;
            }
        }

	else if (AI_State == State_Teleport)
        {
            AI_Timer++;
            if (AI_Timer == 1)
            {

               	npc.teleportTime = 0f;
		        npc.position.X = player.Center.X;
		        npc.position.Y = player.Center.Y + player.height;
		        npc.ai[1] = 2f;
		return;
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

	if (Main.rand.Next(10) == 0)
	{
	Item.NewItem(npc.getRect(), mod.ItemType("OblivionInitiateTrophy"));    
	}	



        if (Main.expertMode)
        {
            Item.NewItem(npc.getRect(), mod.ItemType("OblivionBag"));
        }
        else
        {
            Item.NewItem(npc.getRect(), mod.ItemType("DarkMatter"), 35);
            Item.NewItem(npc.getRect(), mod.ItemType("OblivionEssence"), 10);
        }

    }

    public override void BossLoot(ref string name, ref int potionType)
    {
        potionType = ItemID.SuperHealingPotion;
    }

}
    

}
