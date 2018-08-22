using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace InitiateMod.Blocks
{
	public class PetrifiedWoodBlock : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("PetrifiedWoodBlock");
			AddMapEntry(new Color(200, 200, 0));
			Main.tileSpelunker[Type] = true;
           		minPick = 200;
		}
	}
}