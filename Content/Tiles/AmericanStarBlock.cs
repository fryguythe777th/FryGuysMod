using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace FryGuysMod.Content.Tiles
{
	public class AmericanStarBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;

			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = false;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("American Star Block");
			AddMapEntry(new Color(7, 25, 46), name);

			ItemDrop = ModContent.ItemType<Content.Items.Placeables.AmericanStarBlock>();
			SoundType = SoundID.Tink;
			SoundStyle = 1;
		}
    }
}