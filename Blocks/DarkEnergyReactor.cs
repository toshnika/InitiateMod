using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace InitiateMod.Blocks
{
	public class DarkEnergyReactor : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile(Type);
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Dark Matter Reactor");
			AddMapEntry(new Color(200, 0, 200), name);
			disableSmartCursor = true;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("DarkMatterReactor"));
		}
	}
}