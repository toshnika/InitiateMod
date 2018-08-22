using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace InitiateMod.Blocks
{
	public class SwampTree : ModTree
	{
		private Mod mod
		{
			get
			{
				return ModLoader.GetMod("InitiateMod");
			}
		}

		public override int DropWood()
		{
			return ItemID.RichMahogany;
		}

		public override Texture2D GetTexture()
		{
			return mod.GetTexture("Blocks/SwampTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
		{
			return mod.GetTexture("Blocks/SwampTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
		{
			return mod.GetTexture("Blocks/SwampTree_Branches");
		}
	}
}