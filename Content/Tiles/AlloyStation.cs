using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace FryGuysMod.Content.Tiles
{
	public class AlloyStation : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileNoAttach[Type] = true;

			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Alloy Station");
			AddMapEntry(new Color(22, 21, 21), name);

			AnimationFrameHeight = 36;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<Content.Items.Placeables.AlloyStation>());
		}

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
			frameCounter++;

			if (frameCounter >= 9)
            {
				frameCounter = 0;
				if (++frame >= 4)
                {
					frame = 0;
                }
            }
        }
    }
}