using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using InitiateMod;
using InitiateMod.Items;
using InitiateMod.Items.Misc;
using InitiateMod.Projectiles;

namespace InitiateMod.NPCs.Town
{
	[AutoloadHead]
	public class Enchantress : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "Enchantress";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchantress");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 32;
			npc.height = 54;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

        public override bool CanTownNPCSpawn(int numTownNPCs, int money) //Whether or not the conditions have been met for this town NPC to be able to move into town.
        {
            if (InitiateWorld.downedEnchanter)  //so after the EoC is killed
            {
                return true;
            }
            return false;
        }

        public override string TownNPCName()     //Allows you to give this town NPC any name when it spawns
        {
            switch (WorldGen.genRand.Next(6))
            {
                case 0:
                    return "Nina";
                case 1:
                    return "Arcana";
                case 2:
                    return "Maria";
                case 3:
                    return "Antonina";
                case 4:
                    return "Greta";
                case 5:
                    return "Anna";
                default:
                    return "Anastasia";
            }
        }


        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
        {
            
            switch (Main.rand.Next(4))    //this are the messages when you talk to the npc
            {
                case 0:
                    return "What do you mean? I'm not a reincarnation of the enchanter for goodness sake.";
                case 1:
                    return "Fancy a mint?";
                case 2:
                    return "I actually hate a lot of my job, but people like you pay me well for it";
                case 3:
                    return "Smell that? that's what happens when you fail a food transformation.";
                default:
                    return "I like tortoises.";
                

            }
        }


		public override void SetChatButtons(ref string button, ref string button2)
		{
#pragma warning disable CS0618 // Type or member is obsolete
			button = Lang.inter[28].Value;
#pragma warning restore CS0618 // Type or member is obsolete
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			shop = firstButton;
		}

        public override void SetupShop(Chest shop, ref int nextSlot)       //Allows you to add items to this town NPC's shop. Add an item by setting the defaults of shop.item[nextSlot] then incrementing nextSlot.
        {
            if (InitiateWorld.downedEnchanter)   //this make so when the king slime is killed the town npc will sell this
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("EnchantedShard"));  //an example of how to add a vanilla terraria item
                nextSlot++;

            }

        }
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 36;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
            projType = mod.ProjectileType("friendlyrazorblast");
			attackDelay = 4;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

	}
}