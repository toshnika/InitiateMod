using Terraria;
using Terraria.ModLoader;

namespace InitiateMod.StatusEffects
{
	public class CelestiteSeeker : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Celestite Seeker");
			Description.SetDefault("A celestite seeker is allied with you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			InitiatePlayer modPlayer = (InitiatePlayer)player.GetModPlayer(mod, "InitiatePlayer");
			if (player.ownedProjectileCounts[mod.ProjectileType("CelestiteSeekerStaffProjectile")] > 0)
			{
				modPlayer.CelestiteSeeker = true;
			}
			if (!modPlayer.CelestiteSeeker)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 9999;
			}
		}
	}
}