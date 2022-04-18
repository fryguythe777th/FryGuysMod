using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items
{
	public class Gunpowder : FourthOfJulyItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Highly explosive. Keep in a cool area.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			//Item.value = 10000;
			Item.maxStack = 999;
			Item.rare = ItemRarityID.Green;
		}
	}
}
