using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Weapons
{
	public class Gunpowder : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Highly explosive. Keep in a cool area.");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			//Item.value = 10000;
			Item.rare = ItemRarityID.Green;
		}
	}
}