using System;
using System.Linq;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Placeables
{
	public class AmericanStarBlock : FourthOfJulyItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

        public override void SetDefaults()
        {
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(silver: 5);
			Item.createTile = ModContent.TileType<Content.Tiles.AmericanStarBlock>();
        }
    }
}
