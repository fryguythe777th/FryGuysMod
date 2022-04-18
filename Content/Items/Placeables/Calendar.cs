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
	public class Calendar : ModItem
	{
		public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Allows you to change the season.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
        {
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Content.Tiles.Calendar>();
        }

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.Ectoplasm, 6)
				.AddIngredient(ItemID.Silk, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
        }
    }
}