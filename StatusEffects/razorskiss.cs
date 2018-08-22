using Terraria;
using Terraria.ModLoader;

namespace InitiateMod.StatusEffects
{
	public class razorskiss : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Razor's Kiss");
			Description.SetDefault("Lose all life regen");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<InitiatePlayer>(mod).razorskiss = true;
		}

	}
}
