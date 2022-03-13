using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace FryGuysMod.Content.Tiles
{
	public class Calendar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileNoAttach[Type] = true;

			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.AnchorBottom = default;
			TileObjectData.newTile.AnchorTop = default;
			TileObjectData.newTile.AnchorWall = true;
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Calendar");
			AddMapEntry(new Color(224, 201, 166), name);
		}

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<Content.Items.Placeables.Calendar>());
        }

        public override bool RightClick(int i, int j)
        {
			HitWire(i, j);
			return true;
        }

        public override void HitWire(int i, int j)
        {
			int x = i - Main.tile[i, j].TileFrameX / 18 % 2;
			int y = j - Main.tile[i, j].TileFrameY / 18 % 2;
			for (int l = x; l < x + 2; l++)
            {
				for (int m = y; m < y + 2; m++)
                {
					Wiring.SkipWire(l, m);

					if (Main.tile[l, m].TileFrameX >= 108) //if on frame 4 (each frame is 36 pixel
                    {
						Main.tile[l, m].TileFrameX -= 108; //go back 3 frames to frame 1
						if (l == x && m == y)
                        {
							FryGuySeason.CalendarHalloween = false;
							FryGuySeason.CalendarXMas = false;
							FryGuySeason.CalendarFourthOfJuly = false;
							Main.NewText("No special season will be set for the day.");
						}
                    }
					else
                    {
						Main.tile[l, m].TileFrameX += 36; // otherwise go 1 frame forward
						if (l == x && m == y)
                        {
							if (Main.tile[l, m].TileFrameX >= 72 && Main.tile[l, m].TileFrameX <= 107)
							{
								FryGuySeason.CalendarHalloween = true;
								FryGuySeason.CalendarFourthOfJuly = false;
								FryGuySeason.CalendarXMas = false;
								Main.xMas = false;
								Main.NewText("It is now the spooky season for a day.");
							}
							else if (Main.tile[l, m].TileFrameX >= 108)
							{
								FryGuySeason.CalendarXMas = true;
								FryGuySeason.CalendarHalloween = false;
								Main.halloween = false;
								FryGuySeason.CalendarFourthOfJuly = false;
								Main.NewText("It is now the holiday season for a day.");
							}
							else if (Main.tile[l, m].TileFrameX >= 36 && Main.tile[l, m].TileFrameX <= 73)
							{
								FryGuySeason.CalendarFourthOfJuly = true;
								FryGuySeason.CalendarHalloween = false;
								Main.halloween = false;
								FryGuySeason.CalendarXMas = false;
								Main.xMas = false;
								Main.NewText("It is now the patriotic season for a day.");
							}
						}
                    }
                }
            }
		}
    }
}