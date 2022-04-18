using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace FryGuysMod.Content.Tiles
{
	public class AmericanStripeBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;

			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = false;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("American Stripe Block");
			AddMapEntry(new Color(70, 9, 25), name);

			ItemDrop = ModContent.ItemType<Content.Items.Placeables.AmericanStripeBlock>();
			SoundType = SoundID.Tink;
			SoundStyle = 1;
		}
    }
}