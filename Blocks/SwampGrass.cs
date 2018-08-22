using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InitiateMod.Blocks
{
	public class SwampGrass : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;	
			drop = (ItemID.MudBlock);
			AddMapEntry(new Color(50, 200, 50));
			SetModTree(new SwampTree());
		}
		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return mod.TileType("SwampSapling");
		}
	}
}